// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthAuthorizeEndpointContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.OAuth.Messages;
using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// An event raised after the Authorization Server has processed the request, but before it is passed on to the web application.
  /// Calling RequestCompleted will prevent the request from passing on to the web application.
  /// </summary>
  public class OAuthAuthorizeEndpointContext : EndpointContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>Creates an instance of this context</summary>
    public OAuthAuthorizeEndpointContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      AuthorizeEndpointRequest authorizeRequest)
      : base(context, options)
    {
      this.AuthorizeRequest = authorizeRequest;
    }

    /// <summary>Gets OAuth authorization request data.</summary>
    public AuthorizeEndpointRequest AuthorizeRequest { get; private set; }
  }
}
