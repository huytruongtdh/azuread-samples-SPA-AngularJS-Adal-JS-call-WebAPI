// Decompiled with JetBrains decompiler
// Type: Owin.JwtBearerAuthenticationExtensions
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Owin
{
  /// <summary>
  /// Extension methods provided by the JWT bearer token middleware.
  /// </summary>
  public static class JwtBearerAuthenticationExtensions
  {
    /// <summary>
    /// Adds JWT bearer token middleware to your web application pipeline.
    /// </summary>
    /// <param name="app">The IAppBuilder passed to your configuration method.</param>
    /// <param name="options">An options class that controls the middleware behavior.</param>
    /// <returns>The original app parameter.</returns>
    public static IAppBuilder UseJwtBearerAuthentication(
      this IAppBuilder app,
      JwtBearerAuthenticationOptions options)
    {
      if (app == null)
        throw new ArgumentNullException(nameof (app));
      if (options == null)
        throw new ArgumentNullException(nameof (options));
      JwtFormat jwtFormat = options.TokenValidationParameters == null ? new JwtFormat(options.AllowedAudiences, options.IssuerSecurityKeyProviders) : new JwtFormat(options.TokenValidationParameters);
      if (options.TokenHandler != null)
        jwtFormat.TokenHandler = options.TokenHandler;
      OAuthBearerAuthenticationOptions authenticationOptions = new OAuthBearerAuthenticationOptions();
      authenticationOptions.Realm = options.Realm;
      authenticationOptions.Provider = options.Provider;
      authenticationOptions.AccessTokenFormat = (ISecureDataFormat<AuthenticationTicket>) jwtFormat;
      authenticationOptions.AuthenticationMode = options.AuthenticationMode;
      authenticationOptions.AuthenticationType = options.AuthenticationType;
      authenticationOptions.Description = options.Description;
      OAuthBearerAuthenticationOptions options1 = authenticationOptions;
      app.UseOAuthBearerAuthentication(options1);
      return app;
    }
  }
}
