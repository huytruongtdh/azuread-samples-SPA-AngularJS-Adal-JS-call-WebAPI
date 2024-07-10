// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.ExternalLoginInfo
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using System.Security.Claims;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Used to return information needed to associate an external login
  /// </summary>
  public class ExternalLoginInfo
  {
    /// <summary>Associated login data</summary>
    public UserLoginInfo Login { get; set; }

    /// <summary>Suggested user name for a user</summary>
    public string DefaultUserName { get; set; }

    /// <summary>Email claim from the external identity</summary>
    public string Email { get; set; }

    /// <summary>The external identity</summary>
    public ClaimsIdentity ExternalIdentity { get; set; }
  }
}
