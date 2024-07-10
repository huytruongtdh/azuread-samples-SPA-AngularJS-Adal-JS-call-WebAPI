// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationHandler
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuth
{
    internal class OAuthBearerAuthenticationHandler : AuthenticationHandler<OAuthBearerAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly string _challenge;

        public OAuthBearerAuthenticationHandler(ILogger logger, string challenge)
        {
            _logger = logger;
            _challenge = challenge;
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            try
            {
                // Find token in default location
                string requestToken = null;
                string authorization = Request.Headers.Get("Authorization");
                if (!string.IsNullOrEmpty(authorization))
                {
                    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        requestToken = authorization.Substring("Bearer ".Length).Trim();
                    }
                }

                // Give application opportunity to find from a different location, adjust, or reject token
                var requestTokenContext = new OAuthRequestTokenContext(Context, requestToken);
                await Options.Provider.RequestToken(requestTokenContext);

                // If no token found, no further work possible
                if (string.IsNullOrEmpty(requestTokenContext.Token))
                {
                    return null;
                }

                // Call provider to process the token into data
                var tokenReceiveContext = new AuthenticationTokenReceiveContext(
                    Context,
                    Options.AccessTokenFormat,
                    requestTokenContext.Token);

                await Options.AccessTokenProvider.ReceiveAsync(tokenReceiveContext);
                if (tokenReceiveContext.Ticket == null)
                {
                    tokenReceiveContext.DeserializeTicket(tokenReceiveContext.Token);
                }

                AuthenticationTicket ticket = tokenReceiveContext.Ticket;
                if (ticket == null)
                {
                    _logger.WriteWarning("invalid bearer token received");
                    return null;
                }

                // Validate expiration time if present
                DateTimeOffset currentUtc = Options.SystemClock.UtcNow;

                if (ticket.Properties.ExpiresUtc.HasValue &&
                    ticket.Properties.ExpiresUtc.Value < currentUtc)
                {
                    _logger.WriteWarning("expired bearer token received");
                    return null;
                }

                // Give application final opportunity to override results
                var context = new OAuthValidateIdentityContext(Context, Options, ticket);
                if (ticket != null &&
                    ticket.Identity != null &&
                    ticket.Identity.IsAuthenticated)
                {
                    // bearer token with identity starts validated
                    context.Validated();
                }
                if (Options.Provider != null)
                {
                    await Options.Provider.ValidateIdentity(context);
                }
                if (!context.IsValidated)
                {
                    return null;
                }

                // resulting identity values go back to caller
                return context.Ticket;
            }
            catch (Exception ex)
            {
                _logger.WriteError("Authentication failed", ex);
                return null;
            }
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode != 401)
            {
                return Task.FromResult<object>(null);
            }

            AuthenticationResponseChallenge challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);

            if (challenge != null)
            {
                OAuthChallengeContext challengeContext = new OAuthChallengeContext(Context, _challenge);
                Options.Provider.ApplyChallenge(challengeContext);
            }

            return Task.FromResult<object>(null);
        }
    }
}
