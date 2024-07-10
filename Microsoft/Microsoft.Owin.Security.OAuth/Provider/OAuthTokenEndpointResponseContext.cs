﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthTokenEndpointResponseContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.OAuth.Messages;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used at the end of a token-endpoint-request.
  /// </summary>
  public class OAuthTokenEndpointResponseContext : EndpointContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthTokenEndpointResponseContext" /> class
    /// </summary>
    public OAuthTokenEndpointResponseContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      AuthenticationTicket ticket,
      TokenEndpointRequest tokenEndpointRequest,
      string accessToken,
      IDictionary<string, object> additionalResponseParameters)
      : base(context, options)
    {
      this.Identity = ticket != null ? ticket.Identity : throw new ArgumentNullException(nameof (ticket));
      this.Properties = ticket.Properties;
      this.TokenEndpointRequest = tokenEndpointRequest;
      this.AdditionalResponseParameters = (IDictionary<string, object>) new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.Ordinal);
      this.TokenIssued = this.Identity != null;
      this.AccessToken = accessToken;
      this.AdditionalResponseParameters = additionalResponseParameters;
    }

    /// <summary>Gets the identity of the resource owner.</summary>
    public ClaimsIdentity Identity { get; private set; }

    /// <summary>
    /// Dictionary containing the state of the authentication session.
    /// </summary>
    public AuthenticationProperties Properties { get; private set; }

    /// <summary>The issued Access-Token</summary>
    public string AccessToken { get; private set; }

    /// <summary>Gets information about the token endpoint request.</summary>
    public TokenEndpointRequest TokenEndpointRequest { get; set; }

    /// <summary>Gets whether or not the token should be issued.</summary>
    public bool TokenIssued { get; private set; }

    /// <summary>
    /// Enables additional values to be appended to the token response.
    /// </summary>
    public IDictionary<string, object> AdditionalResponseParameters { get; private set; }

    /// <summary>Issues the token.</summary>
    /// <param name="identity"></param>
    /// <param name="properties"></param>
    public void Issue(ClaimsIdentity identity, AuthenticationProperties properties)
    {
      this.Identity = identity;
      this.Properties = properties;
      this.TokenIssued = true;
    }
  }
}
