// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequestCustomExtension
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object used by TokenEndpointRequest which contains parameter information when the "grant_type" is unrecognized.
  /// </summary>
  public class TokenEndpointRequestCustomExtension
  {
    /// <summary>
    /// The parameter information when the "grant_type" is unrecognized.
    /// </summary>
    public IReadableStringCollection Parameters { get; set; }
  }
}
