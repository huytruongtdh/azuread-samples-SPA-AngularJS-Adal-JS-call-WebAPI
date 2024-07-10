// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.UserStore`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Data.Entity;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  ///     EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and
  ///     IUserRoleStore
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  public class UserStore<TUser> : 
    UserStore<TUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>,
    IUserStore<TUser>,
    IUserStore<TUser, string>,
    IDisposable
    where TUser : IdentityUser
  {
    /// <summary>
    ///     Default constuctor which uses a new instance of a default EntityyDbContext
    /// </summary>
    public UserStore()
      : this((DbContext) new IdentityDbContext())
    {
      this.DisposeContext = true;
    }

    /// <summary>Constructor</summary>
    /// <param name="context"></param>
    public UserStore(DbContext context)
      : base(context)
    {
    }
  }
}
