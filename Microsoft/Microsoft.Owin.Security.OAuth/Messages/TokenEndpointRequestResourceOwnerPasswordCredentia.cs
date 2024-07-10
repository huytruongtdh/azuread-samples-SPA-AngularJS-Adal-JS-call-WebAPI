// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequestResourceOwnerPasswordCredentials
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object used by TokenEndpointRequest when the "grant_type" is "password".
  /// </summary>
  public class TokenEndpointRequestResourceOwnerPasswordCredentials
  {
    /// <summary>
    /// The value passed to the Token endpoint in the "username" parameter
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The value passed to the Token endpoint in the "password" parameter
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The value passed to the Token endpoint in the "scope" parameter
    /// </summary>
    public IList<string> Scope { get; set; }
  }
}
