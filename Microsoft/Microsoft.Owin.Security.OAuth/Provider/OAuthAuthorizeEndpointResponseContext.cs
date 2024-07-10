// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthAuthorizationEndpointResponseContext
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
  /// Provides context information when processing an Authorization Response
  /// </summary>
  public class OAuthAuthorizationEndpointResponseContext : 
    EndpointContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthAuthorizationEndpointResponseContext" /> class
    /// </summary>
    public OAuthAuthorizationEndpointResponseContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      AuthenticationTicket ticket,
      AuthorizeEndpointRequest authorizeEndpointRequest,
      string accessToken,
      string authorizationCode)
      : base(context, options)
    {
      this.Identity = ticket != null ? ticket.Identity : throw new ArgumentNullException(nameof (ticket));
      this.Properties = ticket.Properties;
      this.AuthorizeEndpointRequest = authorizeEndpointRequest;
      this.AdditionalResponseParameters = (IDictionary<string, object>) new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.Ordinal);
      this.AccessToken = accessToken;
      this.AuthorizationCode = authorizationCode;
    }

    /// <summary>Gets the identity of the resource owner.</summary>
    public ClaimsIdentity Identity { get; private set; }

    /// <summary>
    /// Dictionary containing the state of the authentication session.
    /// </summary>
    public AuthenticationProperties Properties { get; private set; }

    /// <summary>
    /// Gets information about the authorize endpoint request.
    /// </summary>
    public AuthorizeEndpointRequest AuthorizeEndpointRequest { get; private set; }

    /// <summary>
    /// Enables additional values to be appended to the token response.
    /// </summary>
    public IDictionary<string, object> AdditionalResponseParameters { get; private set; }

    /// <summary>
    /// The serialized Access-Token. Depending on the flow, it can be null.
    /// </summary>
    public string AccessToken { get; private set; }

    /// <summary>
    /// The created Authorization-Code. Depending on the flow, it can be null.
    /// </summary>
    public string AuthorizationCode { get; private set; }
  }
}
