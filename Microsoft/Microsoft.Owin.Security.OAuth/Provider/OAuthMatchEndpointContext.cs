// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthMatchEndpointContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used when determining the OAuth flow type based on the request.
  /// </summary>
  public class OAuthMatchEndpointContext : EndpointContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthMatchEndpointContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    public OAuthMatchEndpointContext(IOwinContext context, OAuthAuthorizationServerOptions options)
      : base(context, options)
    {
    }

    /// <summary>
    /// Gets whether or not the endpoint is an OAuth authorize endpoint.
    /// </summary>
    public bool IsAuthorizeEndpoint { get; private set; }

    /// <summary>
    /// Gets whether or not the endpoint is an OAuth token endpoint.
    /// </summary>
    public bool IsTokenEndpoint { get; private set; }

    /// <summary>Sets the endpoint type to authorize endpoint.</summary>
    public void MatchesAuthorizeEndpoint()
    {
      this.IsAuthorizeEndpoint = true;
      this.IsTokenEndpoint = false;
    }

    /// <summary>Sets the endpoint type to token endpoint.</summary>
    public void MatchesTokenEndpoint()
    {
      this.IsAuthorizeEndpoint = false;
      this.IsTokenEndpoint = true;
    }

    /// <summary>
    /// Sets the endpoint type to neither authorize nor token.
    /// </summary>
    public void MatchesNothing()
    {
      this.IsAuthorizeEndpoint = false;
      this.IsTokenEndpoint = false;
    }
  }
}
