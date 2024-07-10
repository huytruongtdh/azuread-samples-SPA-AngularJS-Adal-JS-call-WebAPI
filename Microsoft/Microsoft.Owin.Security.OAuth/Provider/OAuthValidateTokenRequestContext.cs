// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthValidateTokenRequestContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.OAuth.Messages;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used in validating an OAuth token request.
  /// </summary>
  public class OAuthValidateTokenRequestContext : 
    BaseValidatingContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthValidateTokenRequestContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="tokenRequest"></param>
    /// <param name="clientContext"></param>
    public OAuthValidateTokenRequestContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      TokenEndpointRequest tokenRequest,
      BaseValidatingClientContext clientContext)
      : base(context, options)
    {
      this.TokenRequest = tokenRequest;
      this.ClientContext = clientContext;
    }

    /// <summary>Gets the token request data.</summary>
    public TokenEndpointRequest TokenRequest { get; private set; }

    /// <summary>Gets information about the client.</summary>
    public BaseValidatingClientContext ClientContext { get; private set; }
  }
}
