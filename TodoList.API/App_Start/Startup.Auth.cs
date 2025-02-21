﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TodoList.API.Providers;
using TodoList.API.Models;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.DataProtection;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin.Security.Jwt;

namespace TodoList.API
{
    public partial class Startup
    {
        private readonly string _authority = $"{ConfigurationManager.AppSettings["ida:AADInstance"]}/{ConfigurationManager.AppSettings["ida:TenantId"]}/v2.0";
        private readonly string _audience = ConfigurationManager.AppSettings["ida:ClientId"];

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true,
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            app.UseFacebookAuthentication(
                appId: "504334028606335",
                //appId: "735746767188407",
                appSecret: "1762119331e12f261870702751ddb176");
            //appSecret: "e6cdaae2c3f5ab70a81580252ae43fd3");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "967294946801-cjcedksq2dsjo7eil53pt1arkvulnr8k.apps.googleusercontent.com",
                ClientSecret = "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",
            });

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = _audience,
                    ValidateIssuer = true,
                    ValidIssuer = _authority,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = GetIssuerSigningKeys(_authority).Result
                }
            });
        }

        private async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeys(string authority)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var openIdConfigUrl = $"{authority}/.well-known/openid-configuration";
                    var openIdConfigResponse = await httpClient.GetStringAsync(openIdConfigUrl);
                    var openIdConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenIdConnectConfiguration>(openIdConfigResponse);
                    var jsonWebKeySetResponse = await httpClient.GetStringAsync(openIdConfig.JwksUri);
                    var jsonWebKeySet = new JsonWebKeySet(jsonWebKeySetResponse);
                    return jsonWebKeySet.GetSigningKeys();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
