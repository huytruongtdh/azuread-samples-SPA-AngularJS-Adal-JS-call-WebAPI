// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationMiddleware
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace Microsoft.Owin.Security.OAuth
{
    /// <summary>
    /// Bearer authentication middleware component which is added to an OWIN pipeline. This class is not
    /// created by application code directly, instead it is added by calling the the IAppBuilder UseOAuthBearerAuthentication
    /// extension method.
    /// </summary>
    public class OAuthBearerAuthenticationMiddleware : AuthenticationMiddleware<OAuthBearerAuthenticationOptions>
    {
        private readonly ILogger _logger;

        private readonly string _challenge;

        /// <summary>
        /// Bearer authentication component which is added to an OWIN pipeline. This constructor is not
        /// called by application code directly, instead it is added by calling the the IAppBuilder UseOAuthBearerAuthentication 
        /// extension method.
        /// </summary>
        public OAuthBearerAuthenticationMiddleware(
            OwinMiddleware next,
            IAppBuilder app,
            OAuthBearerAuthenticationOptions options)
            : base(next, options)
        {
            _logger = app.CreateLogger<OAuthBearerAuthenticationMiddleware>();

            if (!string.IsNullOrWhiteSpace(Options.Challenge))
            {
                _challenge = Options.Challenge;
            }
            else if (string.IsNullOrWhiteSpace(Options.Realm))
            {
                _challenge = "Bearer";
            }
            else
            {
                _challenge = "Bearer realm=\"" + Options.Realm + "\"";
            }

            if (Options.Provider == null)
            {
                Options.Provider = new OAuthBearerAuthenticationProvider();
            }

            if (Options.AccessTokenFormat == null)
            {
                IDataProtector dataProtecter = app.CreateDataProtector(
                    typeof(OAuthBearerAuthenticationMiddleware).Namespace,
                    "Access_Token", "v1");
                Options.AccessTokenFormat = new TicketDataFormat(dataProtecter);
            }

            if (Options.AccessTokenProvider == null)
            {
                Options.AccessTokenProvider = new AuthenticationTokenProvider();
            }
        }

        /// <summary>
        /// Called by the AuthenticationMiddleware base class to create a per-request handler. 
        /// </summary>
        /// <returns>A new instance of the request handler</returns>
        protected override AuthenticationHandler<OAuthBearerAuthenticationOptions> CreateHandler()
        {
            return new OAuthBearerAuthenticationHandler(_logger, _challenge);
        }
    }
}
