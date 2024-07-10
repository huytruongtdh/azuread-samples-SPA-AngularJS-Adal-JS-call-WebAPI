// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthChallengeContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Specifies the HTTP response header for the bearer authentication scheme.
  /// </summary>
  public class OAuthChallengeContext : BaseContext
  {
    /// <summary>
    /// Initializes a new <see cref="T:Microsoft.Owin.Security.OAuth.OAuthRequestTokenContext" />
    /// </summary>
    /// <param name="context">OWIN environment</param>
    /// <param name="challenge">The www-authenticate header value.</param>
    public OAuthChallengeContext(IOwinContext context, string challenge)
      : base(context)
    {
      this.Challenge = challenge;
    }

    /// <summary>The www-authenticate header value.</summary>
    public string Challenge { get; protected set; }
  }
}
