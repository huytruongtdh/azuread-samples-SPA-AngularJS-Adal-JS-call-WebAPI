// Decompiled with JetBrains decompiler
// Type: Owin.GoogleAuthenticationExtensions
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using Microsoft.Owin.Security.Google;
using System;

namespace Owin
{
    /// <summary>
    /// Extension methods for using <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationMiddleware" />
    /// </summary>
    public static class GoogleAuthenticationExtensions
    {
        /// <summary>Authenticate users using Google OAuth 2.0</summary>
        /// <param name="app">The <see cref="T:Owin.IAppBuilder" /> passed to the configuration method</param>
        /// <param name="options">Middleware configuration options</param>
        /// <returns>The updated <see cref="T:Owin.IAppBuilder" /></returns>
        public static IAppBuilder UseGoogleAuthentication(
          this IAppBuilder app,
          GoogleOAuth2AuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            app.Use((object)typeof(GoogleOAuth2AuthenticationMiddleware), (object)app, (object)options);
            return app;
        }

        /// <summary>Authenticate users using Google OAuth 2.0</summary>
        /// <param name="app">The <see cref="T:Owin.IAppBuilder" /> passed to the configuration method</param>
        /// <param name="clientId">The google assigned client id</param>
        /// <param name="clientSecret">The google assigned client secret</param>
        /// <returns>The updated <see cref="T:Owin.IAppBuilder" /></returns>
        public static IAppBuilder UseGoogleAuthentication(
          this IAppBuilder app,
          string clientId,
          string clientSecret)
        {
            return app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}
