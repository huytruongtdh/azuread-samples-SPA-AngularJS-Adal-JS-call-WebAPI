// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequest
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;
using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object representing the information contained in form encoded body of a Token endpoint request.
  /// </summary>
  public class TokenEndpointRequest
  {
    /// <summary>
    /// Creates a new instance populated with values from the form encoded body parameters.
    /// </summary>
    /// <param name="parameters">Form encoded body parameters from a request.</param>
    public TokenEndpointRequest(IReadableStringCollection parameters)
    {
      Func<string, string> func = parameters != null ? new Func<string, string>(parameters.Get) : throw new ArgumentNullException(nameof (parameters));
      this.Parameters = parameters;
      this.GrantType = func("grant_type");
      this.ClientId = func("client_id");
      if (string.Equals(this.GrantType, "authorization_code", StringComparison.Ordinal))
        this.AuthorizationCodeGrant = new TokenEndpointRequestAuthorizationCode()
        {
          Code = func("code"),
          RedirectUri = func("redirect_uri")
        };
      else if (string.Equals(this.GrantType, "client_credentials", StringComparison.Ordinal))
        this.ClientCredentialsGrant = new TokenEndpointRequestClientCredentials()
        {
          Scope = (IList<string>) (func("scope") ?? string.Empty).Split(' ')
        };
      else if (string.Equals(this.GrantType, "refresh_token", StringComparison.Ordinal))
        this.RefreshTokenGrant = new TokenEndpointRequestRefreshToken()
        {
          RefreshToken = func("refresh_token"),
          Scope = (IList<string>) (func("scope") ?? string.Empty).Split(' ')
        };
      else if (string.Equals(this.GrantType, "password", StringComparison.Ordinal))
      {
        this.ResourceOwnerPasswordCredentialsGrant = new TokenEndpointRequestResourceOwnerPasswordCredentials()
        {
          UserName = func("username"),
          Password = func("password"),
          Scope = (IList<string>) (func("scope") ?? string.Empty).Split(' ')
        };
      }
      else
      {
        if (string.IsNullOrEmpty(this.GrantType))
          return;
        this.CustomExtensionGrant = new TokenEndpointRequestCustomExtension()
        {
          Parameters = parameters
        };
      }
    }

    /// <summary>
    /// The form encoded body parameters of the Token endpoint request
    /// </summary>
    public IReadableStringCollection Parameters { get; private set; }

    /// <summary>
    /// The "grant_type" parameter of the Token endpoint request. This parameter is required.
    /// </summary>
    public string GrantType { get; private set; }

    /// <summary>
    /// The "client_id" parameter of the Token endpoint request. This parameter is optional. It might not
    /// be present if the request is authenticated in a different way, for example, by using basic authentication
    /// credentials.
    /// </summary>
    public string ClientId { get; private set; }

    /// <summary>
    /// Data object available when the "grant_type" is "authorization_code".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.1.3
    /// </summary>
    public TokenEndpointRequestAuthorizationCode AuthorizationCodeGrant { get; private set; }

    /// <summary>
    /// Data object available when the "grant_type" is "client_credentials".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.4.2
    /// </summary>
    public TokenEndpointRequestClientCredentials ClientCredentialsGrant { get; private set; }

    /// <summary>
    /// Data object available when the "grant_type" is "refresh_token".
    /// See also http://tools.ietf.org/html/rfc6749#section-6
    /// </summary>
    public TokenEndpointRequestRefreshToken RefreshTokenGrant { get; private set; }

    /// <summary>
    /// Data object available when the "grant_type" is "password".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.3.2
    /// </summary>
    public TokenEndpointRequestResourceOwnerPasswordCredentials ResourceOwnerPasswordCredentialsGrant { get; private set; }

    /// <summary>
    /// Data object available when the "grant_type" is unrecognized.
    /// See also http://tools.ietf.org/html/rfc6749#section-4.5
    /// </summary>
    public TokenEndpointRequestCustomExtension CustomExtensionGrant { get; private set; }

    /// <summary>
    /// True when the "grant_type" is "authorization_code".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.1.3
    /// </summary>
    public bool IsAuthorizationCodeGrantType => this.AuthorizationCodeGrant != null;

    /// <summary>
    /// True when the "grant_type" is "client_credentials".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.4.2
    /// </summary>
    public bool IsClientCredentialsGrantType => this.ClientCredentialsGrant != null;

    /// <summary>
    /// True when the "grant_type" is "refresh_token".
    /// See also http://tools.ietf.org/html/rfc6749#section-6
    /// </summary>
    public bool IsRefreshTokenGrantType => this.RefreshTokenGrant != null;

    /// <summary>
    /// True when the "grant_type" is "password".
    /// See also http://tools.ietf.org/html/rfc6749#section-4.3.2
    /// </summary>
    public bool IsResourceOwnerPasswordCredentialsGrantType => this.ResourceOwnerPasswordCredentialsGrant != null;

    /// <summary>
    /// True when the "grant_type" is unrecognized.
    /// See also http://tools.ietf.org/html/rfc6749#section-4.5
    /// </summary>
    public bool IsCustomExtensionGrantType => this.CustomExtensionGrant != null;
  }
}
