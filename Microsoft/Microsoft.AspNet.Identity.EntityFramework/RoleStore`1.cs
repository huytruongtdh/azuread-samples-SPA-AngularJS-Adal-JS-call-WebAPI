// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.RoleStore`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Data.Entity;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>EntityFramework based implementation</summary>
  /// <typeparam name="TRole"></typeparam>
  public class RoleStore<TRole> : 
    RoleStore<TRole, string, IdentityUserRole>,
    IQueryableRoleStore<TRole>,
    IQueryableRoleStore<TRole, string>,
    IRoleStore<TRole, string>,
    IDisposable
    where TRole : IdentityRole, new()
  {
    /// <summary>Constructor</summary>
    public RoleStore()
      : base((DbContext) new IdentityDbContext())
    {
      this.DisposeContext = true;
    }

    /// <summary>Constructor</summary>
    /// <param name="context"></param>
    public RoleStore(DbContext context)
      : base(context)
    {
    }
  }
}
