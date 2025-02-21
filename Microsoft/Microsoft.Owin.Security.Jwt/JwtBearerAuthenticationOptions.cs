﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Microsoft.Owin.Security.Jwt
{
  /// <summary>Options for JWT Bearer Token handler configuration.</summary>
  public class JwtBearerAuthenticationOptions : AuthenticationOptions
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions" /> class.
    /// </summary>
    public JwtBearerAuthenticationOptions()
      : base("Bearer")
    {
    }

    /// <summary>
    /// Gets or sets the allowed audiences an inbound JWT will be checked against.
    /// </summary>
    /// <value>The allowed audiences.</value>
    public IEnumerable<string> AllowedAudiences { get; set; }

    /// <summary>
    /// Gets or sets the issuer security token providers which provide the signing keys
    /// a JWT signature is checked against.
    /// </summary>
    /// <value>The issuer security token providers.</value>
    public IEnumerable<IIssuerSecurityKeyProvider> IssuerSecurityKeyProviders { get; set; }

    /// <summary>Gets or sets the authentication provider.</summary>
    /// <value>The provider.</value>
    public IOAuthBearerAuthenticationProvider Provider { get; set; }

    /// <summary>Gets or sets the authentication realm.</summary>
    /// <value>The authentication realm.</value>
    public string Realm { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="P:Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions.TokenValidationParameters" /> used to determine if a token is valid.
    /// </summary>
    public TokenValidationParameters TokenValidationParameters { get; set; }

    /// <summary>
    /// A System.IdentityModel.Tokens.SecurityTokenHandler designed for creating and validating Json Web Tokens.
    /// </summary>
    public JwtSecurityTokenHandler TokenHandler { get; set; }
  }
}
