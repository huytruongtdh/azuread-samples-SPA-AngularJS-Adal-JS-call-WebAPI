// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityRole`2
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System.Collections.Generic;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>Represents a Role entity</summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TUserRole"></typeparam>
  public class IdentityRole<TKey, TUserRole> : IRole<TKey> where TUserRole : IdentityUserRole<TKey>
  {
    /// <summary>Constructor</summary>
    public IdentityRole() => this.Users = (ICollection<TUserRole>) new List<TUserRole>();

    /// <summary>Navigation property for users in the role</summary>
    public virtual ICollection<TUserRole> Users { get; private set; }

    /// <summary>Role id</summary>
    public TKey Id { get; set; }

    /// <summary>Role name</summary>
    public string Name { get; set; }
  }
}
