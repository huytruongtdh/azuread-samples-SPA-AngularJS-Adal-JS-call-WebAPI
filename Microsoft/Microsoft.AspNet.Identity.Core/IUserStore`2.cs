// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that exposes basic user management apis</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserStore<TUser, in TKey> : IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Insert a new user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task CreateAsync(TUser user);

    /// <summary>Update a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task UpdateAsync(TUser user);

    /// <summary>Delete a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task DeleteAsync(TUser user);

    /// <summary>Finds a user</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<TUser> FindByIdAsync(TKey userId);

    /// <summary>Find a user by name</summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<TUser> FindByNameAsync(string userName);
  }
}
