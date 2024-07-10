using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Facebook;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TodoList.API.Models;

namespace TodoList.API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private ApplicationUserManager _userManager;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            _userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            ApplicationUser user = await _userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(_userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(_userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AddAdditionalClaims(oAuthIdentity, user);

            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override async Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            if (context.GrantType == "facebook")
            {
                _userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
                var facebookToken = context.Parameters["assertion"];

                try
                {
                    var fb = new FacebookClient(facebookToken);
                    dynamic fbUser = await fb.GetTaskAsync("me?fields=id,name,email");
                    if (fbUser == null)
                    {
                        context.SetError("invalid_grant", "The Facebook token is expired or invalid.");
                        return;
                    }

                    var user = await _userManager.FindByEmailAsync((string)fbUser.email);
                    if (user == null)
                    {
                        var properties = CreateProperties((string)fbUser.email, (string)fbUser.name);
                        var unregisteredIdentity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

                        var ticket = new AuthenticationTicket(unregisteredIdentity, properties);
                        context.Validated(ticket);
                    }
                    else
                    {
                        var oAuthIdentity = await user.GenerateUserIdentityAsync(_userManager, OAuthDefaults.AuthenticationType);

                        var roles = oAuthIdentity.Claims.Where(x => x.Type == ClaimTypes.Role).ToList(); // oAuthIdentity.RoleClaimType;

                        var properties = CreateProperties((string)fbUser.email, (string)fbUser.name, roles: string.Join(",", roles));

                        var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                        context.Validated(ticket);
                    }
                }
                catch (Exception ex)
                {
                    context.SetError("invalid_grant", ex.Message);
                    return;
                }
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");
  
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }
            else
            {
                var expectedRedirectUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientRedirectUrl"].TrimEnd('/'));
                if (expectedRedirectUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName, string name = null, string roles = null, string phoneNumber = null)
        {
            var data = new Dictionary<string, string>
            {
                { "userName", userName }
            };

            if (!string.IsNullOrEmpty(name))
                data.Add("fullName", name);

            if (!string.IsNullOrEmpty(roles))
                data.Add("roles", roles);

            if (!string.IsNullOrEmpty(phoneNumber))
                data.Add("required_action", "register");

            return new AuthenticationProperties(data);
        }

        public static void AddAdditionalClaims(ClaimsIdentity oAuthIdentity, ApplicationUser user)
        {
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.GivenName));
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
        }
    }
}