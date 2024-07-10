// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthValidateAuthorizeRequestContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.OAuth.Messages;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used in validating an OAuth authorization request.
  /// </summary>
  public class OAuthValidateAuthorizeRequestContext : 
    BaseValidatingContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthValidateAuthorizeRequestContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="authorizeRequest"></param>
    /// <param name="clientContext"></param>
    public OAuthValidateAuthorizeRequestContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      AuthorizeEndpointRequest authorizeRequest,
      OAuthValidateClientRedirectUriContext clientContext)
      : base(context, options)
    {
      this.AuthorizeRequest = authorizeRequest;
      this.ClientContext = clientContext;
    }

    /// <summary>Gets OAuth authorization request data.</summary>
    public AuthorizeEndpointRequest AuthorizeRequest { get; private set; }

    /// <summary>Gets data about the OAuth client.</summary>
    public OAuthValidateClientRedirectUriContext ClientContext { get; private set; }
  }
}
