// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationProvider
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>OAuth bearer token middleware provider</summary>
  public class OAuthBearerAuthenticationProvider : IOAuthBearerAuthenticationProvider
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationProvider" /> class
    /// </summary>
    public OAuthBearerAuthenticationProvider()
    {
      this.OnRequestToken = (Func<OAuthRequestTokenContext, Task>) (context => (Task) Task.FromResult<object>((object) null));
      this.OnValidateIdentity = (Func<OAuthValidateIdentityContext, Task>) (context => (Task) Task.FromResult<object>((object) null));
      this.OnApplyChallenge = (Func<OAuthChallengeContext, Task>) (context =>
      {
        context.OwinContext.Response.Headers.AppendValues("WWW-Authenticate", context.Challenge);
        return (Task) Task.FromResult<int>(0);
      });
    }

    /// <summary>Handles processing OAuth bearer token.</summary>
    public Func<OAuthRequestTokenContext, Task> OnRequestToken { get; set; }

    /// <summary>
    /// Handles validating the identity produced from an OAuth bearer token.
    /// </summary>
    public Func<OAuthValidateIdentityContext, Task> OnValidateIdentity { get; set; }

    /// <summary>
    /// Handles applying the authentication challenge to the response message.
    /// </summary>
    public Func<OAuthChallengeContext, Task> OnApplyChallenge { get; set; }

    /// <summary>Handles processing OAuth bearer token.</summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task RequestToken(OAuthRequestTokenContext context) => this.OnRequestToken(context);

    /// <summary>
    /// Handles validating the identity produced from an OAuth bearer token.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task ValidateIdentity(OAuthValidateIdentityContext context) => this.OnValidateIdentity(context);

    /// <summary>
    /// Handles applying the authentication challenge to the response message.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task ApplyChallenge(OAuthChallengeContext context) => this.OnApplyChallenge(context);
  }
}
