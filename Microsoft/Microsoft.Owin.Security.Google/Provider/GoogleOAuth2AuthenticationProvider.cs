// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationProvider
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Google
{
  /// <summary>
  /// Default <see cref="T:Microsoft.Owin.Security.Google.IGoogleOAuth2AuthenticationProvider" /> implementation.
  /// </summary>
  public class GoogleOAuth2AuthenticationProvider : IGoogleOAuth2AuthenticationProvider
  {
    /// <summary>
    /// Initializes a <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationProvider" />
    /// </summary>
    public GoogleOAuth2AuthenticationProvider()
    {
      this.OnAuthenticated = (Func<GoogleOAuth2AuthenticatedContext, Task>) (context => (Task) Task.FromResult<object>((object) null));
      this.OnReturnEndpoint = (Func<GoogleOAuth2ReturnEndpointContext, Task>) (context => (Task) Task.FromResult<object>((object) null));
      this.OnApplyRedirect = (Action<GoogleOAuth2ApplyRedirectContext>) (context => context.Response.Redirect(context.RedirectUri));
    }

    /// <summary>
    /// Gets or sets the function that is invoked when the Authenticated method is invoked.
    /// </summary>
    public Func<GoogleOAuth2AuthenticatedContext, Task> OnAuthenticated { get; set; }

    /// <summary>
    /// Gets or sets the function that is invoked when the ReturnEndpoint method is invoked.
    /// </summary>
    public Func<GoogleOAuth2ReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

    /// <summary>
    /// Gets or sets the delegate that is invoked when the ApplyRedirect method is invoked.
    /// </summary>
    public Action<GoogleOAuth2ApplyRedirectContext> OnApplyRedirect { get; set; }

    /// <summary>
    /// Invoked whenever Google succesfully authenticates a user
    /// </summary>
    /// <param name="context">Contains information about the login session as well as the user <see cref="T:System.Security.Claims.ClaimsIdentity" />.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    public virtual Task Authenticated(GoogleOAuth2AuthenticatedContext context) => this.OnAuthenticated(context);

    /// <summary>
    /// Invoked prior to the <see cref="T:System.Security.Claims.ClaimsIdentity" /> being saved in a local cookie and the browser being redirected to the originally requested URL.
    /// </summary>
    /// <param name="context">Contains context information and authentication ticket of the return endpoint.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    public virtual Task ReturnEndpoint(GoogleOAuth2ReturnEndpointContext context) => this.OnReturnEndpoint(context);

    /// <summary>
    /// Called when a Challenge causes a redirect to authorize endpoint in the Google OAuth 2.0 middleware
    /// </summary>
    /// <param name="context">Contains redirect URI and <see cref="T:Microsoft.Owin.Security.AuthenticationProperties" /> of the challenge </param>
    public virtual void ApplyRedirect(GoogleOAuth2ApplyRedirectContext context) => this.OnApplyRedirect(context);
  }
}
