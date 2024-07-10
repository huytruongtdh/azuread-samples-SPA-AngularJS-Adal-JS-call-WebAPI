// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthRequestTokenContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Specifies the HTTP request header for the bearer authentication scheme.
  /// </summary>
  public class OAuthRequestTokenContext : BaseContext
  {
    /// <summary>
    /// Initializes a new <see cref="T:Microsoft.Owin.Security.OAuth.OAuthRequestTokenContext" />
    /// </summary>
    /// <param name="context">OWIN environment</param>
    /// <param name="token">The authorization header value.</param>
    public OAuthRequestTokenContext(IOwinContext context, string token)
      : base(context)
    {
      this.Token = token;
    }

    /// <summary>The authorization header value</summary>
    public string Token { get; set; }
  }
}
