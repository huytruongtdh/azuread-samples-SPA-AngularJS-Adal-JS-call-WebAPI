// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequestClientCredentials
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object used by TokenEndpointRequest when the "grant_type" is "client_credentials".
  /// </summary>
  public class TokenEndpointRequestClientCredentials
  {
    /// <summary>
    /// The value passed to the Token endpoint in the "scope" parameter
    /// </summary>
    public IList<string> Scope { get; set; }
  }
}
