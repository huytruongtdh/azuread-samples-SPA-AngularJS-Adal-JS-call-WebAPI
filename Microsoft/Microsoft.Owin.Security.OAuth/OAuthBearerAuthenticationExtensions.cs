// Decompiled with JetBrains decompiler
// Type: Owin.OAuthBearerAuthenticationExtensions
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Owin
{
    /// <summary>
    /// Extension methods to add OAuth Bearer authentication capabilities to an OWIN application pipeline
    /// </summary>
    public static class OAuthBearerAuthenticationExtensions
    {
        /// <summary>
        /// Adds Bearer token processing to an OWIN application pipeline. This middleware understands appropriately
        /// formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        /// claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode 
        /// is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        /// any time to obtain the claims from the request's bearer token.
        /// See also http://tools.ietf.org/html/rfc6749
        /// </summary>
        /// <param name="app">The web application builder</param>
        /// <param name="options">Options which control the processing of the bearer header.</param>
        /// <returns>The application builder</returns>
        public static IAppBuilder UseOAuthBearerAuthentication(this IAppBuilder app, OAuthBearerAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.Use(typeof(OAuthBearerAuthenticationMiddleware), app, options);
            app.UseStageMarker(PipelineStage.Authenticate);
            return app;
        }
    }
}
