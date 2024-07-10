// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthValidateClientRedirectUriContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>Contains data about the OAuth client redirect URI</summary>
  public class OAuthValidateClientRedirectUriContext : BaseValidatingClientContext
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthValidateClientRedirectUriContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="clientId"></param>
    /// <param name="redirectUri"></param>
    public OAuthValidateClientRedirectUriContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      string clientId,
      string redirectUri)
      : base(context, options, clientId)
    {
      this.RedirectUri = redirectUri;
    }

    /// <summary>Gets the client redirect URI</summary>
    public string RedirectUri { get; private set; }

    /// <summary>
    /// Marks this context as validated by the application. IsValidated becomes true and HasError becomes false as a result of calling.
    /// </summary>
    /// <returns></returns>
    public override bool Validated() => !string.IsNullOrEmpty(this.RedirectUri) && base.Validated();

    /// <summary>
    /// Checks the redirect URI to determine whether it equals <see cref="P:Microsoft.Owin.Security.OAuth.OAuthValidateClientRedirectUriContext.RedirectUri" />.
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public bool Validated(string redirectUri)
    {
      if (redirectUri == null)
        throw new ArgumentNullException(nameof (redirectUri));
      if (!string.IsNullOrEmpty(this.RedirectUri) && !string.Equals(this.RedirectUri, redirectUri, StringComparison.Ordinal))
        return false;
      this.RedirectUri = redirectUri;
      return this.Validated();
    }
  }
}
