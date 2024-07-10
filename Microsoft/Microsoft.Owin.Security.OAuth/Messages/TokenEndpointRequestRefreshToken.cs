// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequestRefreshToken
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object used by TokenEndpointRequest when the "grant_type" parameter is "refresh_token".
  /// </summary>
  public class TokenEndpointRequestRefreshToken
  {
    /// <summary>
    /// The value passed to the Token endpoint in the "refresh_token" parameter
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// The value passed to the Token endpoint in the "scope" parameter
    /// </summary>
    public IList<string> Scope { get; set; }
  }
}
