// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityUser
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>Default EntityFramework IUser implementation</summary>
  public class IdentityUser : 
    IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>,
    IUser,
    IUser<string>
  {
    /// <summary>Constructor which creates a new Guid for the Id</summary>
    public IdentityUser() => this.Id = Guid.NewGuid().ToString();

    /// <summary>Constructor that takes a userName</summary>
    /// <param name="userName"></param>
    public IdentityUser(string userName)
      : this()
    {
      this.UserName = userName;
    }
  }
}
