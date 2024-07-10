// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.IGoogleOAuth2AuthenticationProvider
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Google
{
  /// <summary>
  /// Specifies callback methods which the <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationMiddleware"></see> invokes to enable developer control over the authentication process. /&gt;
  /// </summary>
  public interface IGoogleOAuth2AuthenticationProvider
  {
    /// <summary>
    /// Invoked whenever Google succesfully authenticates a user
    /// </summary>
    /// <param name="context">Contains information about the login session as well as the user <see cref="T:System.Security.Claims.ClaimsIdentity" />.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    Task Authenticated(GoogleOAuth2AuthenticatedContext context);

    /// <summary>
    /// Invoked prior to the <see cref="T:System.Security.Claims.ClaimsIdentity" /> being saved in a local cookie and the browser being redirected to the originally requested URL.
    /// </summary>
    /// <param name="context">Contains context information and authentication ticket of the return endpoint.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    Task ReturnEndpoint(GoogleOAuth2ReturnEndpointContext context);

    /// <summary>
    /// Called when a Challenge causes a redirect to authorize endpoint in the Google OAuth 2.0 middleware
    /// </summary>
    /// <param name="context">Contains redirect URI and <see cref="T:Microsoft.Owin.Security.AuthenticationProperties" /> of the challenge </param>
    void ApplyRedirect(GoogleOAuth2ApplyRedirectContext context);
  }
}
