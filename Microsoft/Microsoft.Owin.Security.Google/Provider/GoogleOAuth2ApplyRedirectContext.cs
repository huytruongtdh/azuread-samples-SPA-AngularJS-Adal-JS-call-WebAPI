// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.GoogleOAuth2ApplyRedirectContext
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Google
{
  /// <summary>
  /// Context passed when a Challenge causes a redirect to authorize endpoint in the Google OAuth 2.0 middleware
  /// </summary>
  public class GoogleOAuth2ApplyRedirectContext : BaseContext<GoogleOAuth2AuthenticationOptions>
  {
    /// <summary>Creates a new context object.</summary>
    /// <param name="context">The OWIN request context</param>
    /// <param name="options">The Google OAuth 2.0 middleware options</param>
    /// <param name="properties">The authenticaiton properties of the challenge</param>
    /// <param name="redirectUri">The initial redirect URI</param>
    public GoogleOAuth2ApplyRedirectContext(
      IOwinContext context,
      GoogleOAuth2AuthenticationOptions options,
      AuthenticationProperties properties,
      string redirectUri)
      : base(context, options)
    {
      this.RedirectUri = redirectUri;
      this.Properties = properties;
    }

    /// <summary>Gets the URI used for the redirect operation.</summary>
    public string RedirectUri { get; private set; }

    /// <summary>Gets the authenticaiton properties of the challenge</summary>
    public AuthenticationProperties Properties { get; private set; }
  }
}
