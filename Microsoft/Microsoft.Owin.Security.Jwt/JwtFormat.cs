// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.JwtFormat
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Microsoft.Owin.Security.Jwt
{
  /// <summary>Signs and validates JSON Web Tokens.</summary>
  public class JwtFormat : ISecureDataFormat<AuthenticationTicket>
  {
    private readonly TokenValidationParameters _validationParameters;
    private readonly IEnumerable<IIssuerSecurityKeyProvider> _issuerCredentialProviders;
    private JwtSecurityTokenHandler _tokenHandler;

    /// <summary>
    /// Creates a new JwtFormat with TokenHandler and UseTokenLifetime enabled by default.
    /// </summary>
    protected JwtFormat()
    {
      this.TokenHandler = new JwtSecurityTokenHandler();
      this.UseTokenLifetime = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.JwtFormat" /> class.
    /// </summary>
    /// <param name="allowedAudience">The allowed audience for JWTs.</param>
    /// <param name="issuerCredentialProvider">The issuer credential provider.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown if the <paramref name="issuerCredentialProvider" /> is null.</exception>
    public JwtFormat(
      string allowedAudience,
      IIssuerSecurityKeyProvider issuerCredentialProvider)
      : this()
    {
      if (string.IsNullOrWhiteSpace(allowedAudience))
        throw new ArgumentNullException(nameof (allowedAudience));
      if (issuerCredentialProvider == null)
        throw new ArgumentNullException(nameof (issuerCredentialProvider));
      this._validationParameters = new TokenValidationParameters()
      {
        ValidAudience = allowedAudience,
        AuthenticationType = "JWT"
      };
      this._issuerCredentialProviders = (IEnumerable<IIssuerSecurityKeyProvider>) new IIssuerSecurityKeyProvider[1]
      {
        issuerCredentialProvider
      };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.JwtFormat" /> class.
    /// </summary>
    /// <param name="allowedAudiences">The allowed audience for JWTs.</param>
    /// <param name="issuerCredentialProviders">The issuer credential provider.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown if the <paramref name="issuerCredentialProviders" /> is null.</exception>
    public JwtFormat(
      IEnumerable<string> allowedAudiences,
      IEnumerable<IIssuerSecurityKeyProvider> issuerCredentialProviders)
      : this()
    {
      List<string> source = allowedAudiences != null ? new List<string>(allowedAudiences) : throw new ArgumentNullException(nameof (allowedAudiences));
      if (!source.Any<string>())
        throw new ArgumentOutOfRangeException(nameof (allowedAudiences), Microsoft.Owin.Security.Jwt.Properties.Resources.Exception_AudiencesMustBeSpecified);
      if (issuerCredentialProviders == null)
        throw new ArgumentNullException(nameof (issuerCredentialProviders));
      if (!new List<IIssuerSecurityKeyProvider>(issuerCredentialProviders).Any<IIssuerSecurityKeyProvider>())
        throw new ArgumentOutOfRangeException(nameof (issuerCredentialProviders), Microsoft.Owin.Security.Jwt.Properties.Resources.Exception_IssuerCredentialProvidersMustBeSpecified);
      this._validationParameters = new TokenValidationParameters()
      {
        ValidAudiences = (IEnumerable<string>) source,
        AuthenticationType = "JWT"
      };
      this._issuerCredentialProviders = issuerCredentialProviders;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.JwtFormat" /> class.
    /// </summary>
    /// <param name="validationParameters"> <see cref="T:Microsoft.IdentityModel.Tokens.TokenValidationParameters" /> used to determine if a token is valid.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown if the <paramref name="validationParameters" /> is null.</exception>
    public JwtFormat(TokenValidationParameters validationParameters)
      : this()
    {
      this._validationParameters = validationParameters != null ? validationParameters : throw new ArgumentNullException(nameof (validationParameters));
      if (!string.IsNullOrWhiteSpace(this._validationParameters.AuthenticationType))
        return;
      this._validationParameters.AuthenticationType = "JWT";
    }

    public JwtFormat(
      TokenValidationParameters validationParameters,
      IIssuerSecurityKeyProvider issuerCredentialProvider)
      : this(validationParameters)
    {
      this._issuerCredentialProviders = issuerCredentialProvider != null ? (IEnumerable<IIssuerSecurityKeyProvider>) new IIssuerSecurityKeyProvider[1]
      {
        issuerCredentialProvider
      } : throw new ArgumentNullException(nameof (issuerCredentialProvider));
    }

    /// <summary>
    /// Gets or sets a value indicating whether JWT issuers should be validated.
    /// </summary>
    /// <value>true if the issuer should be validate; otherwise, false.</value>
    public bool ValidateIssuer
    {
      get => this._validationParameters.ValidateIssuer;
      set => this._validationParameters.ValidateIssuer = value;
    }

    /// <summary>
    /// A System.IdentityModel.Tokens.SecurityTokenHandler designed for creating and validating Json Web Tokens.
    /// </summary>
    public JwtSecurityTokenHandler TokenHandler
    {
      get => this._tokenHandler;
      set => this._tokenHandler = value != null ? value : throw new ArgumentNullException(nameof (value));
    }

    /// <summary>
    /// Indicates that the authentication session lifetime (e.g. cookies) should match that of the authentication token.
    /// If the token does not provide lifetime information then normal session lifetimes will be used.
    /// This is enabled by default.
    /// </summary>
    public bool UseTokenLifetime { get; set; }

    /// <summary>
    /// Transforms the specified authentication ticket into a JWT.
    /// </summary>
    /// <param name="data">The authentication ticket to transform into a JWT.</param>
    /// <returns></returns>
    public string Protect(AuthenticationTicket data) => throw new NotSupportedException();

    /// <summary>
    /// Validates the specified JWT and builds an AuthenticationTicket from it.
    /// </summary>
    /// <param name="protectedText">The JWT to validate.</param>
    /// <returns>An AuthenticationTicket built from the <paramref name="protectedText" /></returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if the <paramref name="protectedText" /> is null.</exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">Thrown if the <paramref name="protectedText" /> is not a JWT.</exception>
    public AuthenticationTicket Unprotect(string protectedText)
    {
      if (string.IsNullOrWhiteSpace(protectedText))
        throw new ArgumentNullException(nameof (protectedText));
      if (!(this.TokenHandler.ReadToken(protectedText) is JwtSecurityToken))
        throw new ArgumentOutOfRangeException(nameof (protectedText), Microsoft.Owin.Security.Jwt.Properties.Resources.Exception_InvalidJwt);
      TokenValidationParameters validationParameters = this._validationParameters;
      if (this._issuerCredentialProviders != null)
      {
        validationParameters = validationParameters.Clone();
        IEnumerable<string> second = this._issuerCredentialProviders.Select<IIssuerSecurityKeyProvider, string>((Func<IIssuerSecurityKeyProvider, string>) (provider => provider.Issuer));
        validationParameters.ValidIssuers = validationParameters.ValidIssuers != null ? validationParameters.ValidIssuers.Concat<string>(second) : second;
        List<SecurityKey> list = this._issuerCredentialProviders.Select<IIssuerSecurityKeyProvider, IEnumerable<SecurityKey>>((Func<IIssuerSecurityKeyProvider, IEnumerable<SecurityKey>>) (provider => provider.SecurityKeys)).Aggregate<IEnumerable<SecurityKey>>((Func<IEnumerable<SecurityKey>, IEnumerable<SecurityKey>, IEnumerable<SecurityKey>>) ((left, right) => left.Concat<SecurityKey>(right))).ToList<SecurityKey>();
        validationParameters.IssuerSigningKeys = validationParameters.IssuerSigningKeys != null ? validationParameters.IssuerSigningKeys.Concat<SecurityKey>((IEnumerable<SecurityKey>) list) : (IEnumerable<SecurityKey>) list;
      }
      SecurityToken validatedToken;
      ClaimsIdentity identity = (ClaimsIdentity) this.TokenHandler.ValidateToken(protectedText, validationParameters, out validatedToken).Identity;
      AuthenticationProperties properties = new AuthenticationProperties();
      if (this.UseTokenLifetime)
      {
        DateTime validFrom = validatedToken.ValidFrom;
        if (validFrom != DateTime.MinValue)
          properties.IssuedUtc = new DateTimeOffset?((DateTimeOffset) validFrom.ToUniversalTime());
        DateTime validTo = validatedToken.ValidTo;
        if (validTo != DateTime.MinValue)
          properties.ExpiresUtc = new DateTimeOffset?((DateTimeOffset) validTo.ToUniversalTime());
        properties.AllowRefresh = new bool?(false);
      }
      return new AuthenticationTicket(identity, properties);
    }
  }
}
