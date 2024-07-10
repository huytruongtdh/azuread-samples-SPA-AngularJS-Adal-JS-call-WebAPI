// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.DefaultAuthenticationTypes
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Default authentication types values</summary>
  public static class DefaultAuthenticationTypes
  {
    /// <summary>
    ///     Default value for the main application cookie used by UseSignInCookies
    /// </summary>
    public const string ApplicationCookie = "ApplicationCookie";
    /// <summary>
    ///     Default value used for the ExternalSignInAuthenticationType configured by UseSignInCookies
    /// </summary>
    public const string ExternalCookie = "ExternalCookie";
    /// <summary>
    ///     Default value used by the UseOAuthBearerTokens method
    /// </summary>
    public const string ExternalBearer = "ExternalBearer";
    /// <summary>
    ///     Default value for authentication type used for two factor partial sign in
    /// </summary>
    public const string TwoFactorCookie = "TwoFactorCookie";
    /// <summary>
    ///     Default value for authentication type used for two factor remember browser
    /// </summary>
    public const string TwoFactorRememberBrowserCookie = "TwoFactorRememberBrowser";
  }
}
