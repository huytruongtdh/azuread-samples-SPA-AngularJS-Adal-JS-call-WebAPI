// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.TokenEndpointRequestAuthorizationCode
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object used by TokenEndpointRequest when the "grant_type" is "authorization_code".
  /// </summary>
  public class TokenEndpointRequestAuthorizationCode
  {
    /// <summary>
    /// The value passed to the Token endpoint in the "code" parameter
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// The value passed to the Token endpoint in the "redirect_uri" parameter. This MUST be provided by the caller
    /// if the original visit to the Authorize endpoint contained a "redirect_uri" parameter.
    /// </summary>
    public string RedirectUri { get; set; }
  }
}
