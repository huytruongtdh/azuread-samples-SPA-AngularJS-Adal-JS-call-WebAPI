// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityRole
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>Represents a Role entity</summary>
  public class IdentityRole : IdentityRole<string, IdentityUserRole>
  {
    /// <summary>Constructor</summary>
    public IdentityRole() => this.Id = Guid.NewGuid().ToString();

    /// <summary>Constructor</summary>
    /// <param name="roleName"></param>
    public IdentityRole(string roleName)
      : this()
    {
      this.Name = roleName;
    }
  }
}
