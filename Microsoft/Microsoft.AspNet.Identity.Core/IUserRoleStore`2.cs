// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserRoleStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that maps users to their roles</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserRoleStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Adds a user to a role</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    Task AddToRoleAsync(TUser user, string roleName);

    /// <summary>Removes the role for the user</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    Task RemoveFromRoleAsync(TUser user, string roleName);

    /// <summary>Returns the roles for this user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<IList<string>> GetRolesAsync(TUser user);

    /// <summary>Returns true if a user is in the role</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    Task<bool> IsInRoleAsync(TUser user, string roleName);
  }
}
