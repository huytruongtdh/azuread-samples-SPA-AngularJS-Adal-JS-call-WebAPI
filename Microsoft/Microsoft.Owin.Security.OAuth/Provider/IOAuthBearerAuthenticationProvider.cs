// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.IOAuthBearerAuthenticationProvider
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Specifies callback methods which the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationMiddleware"></see> invokes to enable developer control over the authentication process. /&gt;
  /// </summary>
  public interface IOAuthBearerAuthenticationProvider
  {
    /// <summary>
    /// Invoked before the <see cref="T:System.Security.Claims.ClaimsIdentity" /> is created. Gives the application an
    /// opportunity to find the identity from a different location, adjust, or reject the token.
    /// </summary>
    /// <param name="context">Contains the token string.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    Task RequestToken(OAuthRequestTokenContext context);

    /// <summary>
    /// Called each time a request identity has been validated by the middleware. By implementing this method the
    /// application may alter or reject the identity which has arrived with the request.
    /// </summary>
    /// <param name="context">Contains information about the login session as well as the user <see cref="T:System.Security.Claims.ClaimsIdentity" />.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    Task ValidateIdentity(OAuthValidateIdentityContext context);

    /// <summary>
    /// Called each time a challenge is being sent to the client. By implementing this method the application
    /// may modify the challenge as needed.
    /// </summary>
    /// <param name="context">Contains the default challenge.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.</returns>
    Task ApplyChallenge(OAuthChallengeContext context);
  }
}
