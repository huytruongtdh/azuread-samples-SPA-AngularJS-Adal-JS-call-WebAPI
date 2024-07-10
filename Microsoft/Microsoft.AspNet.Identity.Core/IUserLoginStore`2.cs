// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserLoginStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Interface that maps users to login providers, i.e. Google, Facebook, Twitter, Microsoft
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserLoginStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>
    ///     Adds a user login with the specified provider and key
    /// </summary>
    /// <param name="user"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    Task AddLoginAsync(TUser user, UserLoginInfo login);

    /// <summary>
    ///     Removes the user login with the specified combination if it exists
    /// </summary>
    /// <param name="user"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    Task RemoveLoginAsync(TUser user, UserLoginInfo login);

    /// <summary>Returns the linked accounts for this user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user);

    /// <summary>Returns the user associated with this login</summary>
    /// <returns></returns>
    Task<TUser> FindAsync(UserLoginInfo login);
  }
}
