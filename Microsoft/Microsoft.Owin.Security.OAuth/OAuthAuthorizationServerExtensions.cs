// Decompiled with JetBrains decompiler
// Type: Owin.OAuthAuthorizationServerExtensions
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.OAuth;
using System;

namespace Owin
{
    /// <summary>
    /// Extension methods to add Authorization Server capabilities to an OWIN pipeline
    /// </summary>
    /// <summary>
    /// Extension methods to add Authorization Server capabilities to an OWIN pipeline
    /// </summary>
    public static class OAuthAuthorizationServerExtensions
    {
        /// <summary>
        /// Adds OAuth2 Authorization Server capabilities to an OWIN web application. This middleware
        /// performs the request processing for the Authorize and Token endpoints defined by the OAuth2 specification.
        /// See also http://tools.ietf.org/html/rfc6749
        /// </summary>
        /// <param name="app">The web application builder</param>
        /// <param name="options">Options which control the behavior of the Authorization Server.</param>
        /// <returns>The application builder</returns>
        public static IAppBuilder UseOAuthAuthorizationServer(this IAppBuilder app, OAuthAuthorizationServerOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.Use(typeof(OAuthAuthorizationServerMiddleware), app, options);
            return app;
        }
    }
}
