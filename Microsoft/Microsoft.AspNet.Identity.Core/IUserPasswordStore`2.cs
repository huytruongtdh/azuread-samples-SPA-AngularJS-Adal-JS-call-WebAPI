// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserPasswordStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Stores a user's password hash</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserPasswordStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Set the user password hash</summary>
    /// <param name="user"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    Task SetPasswordHashAsync(TUser user, string passwordHash);

    /// <summary>Get the user password hash</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> GetPasswordHashAsync(TUser user);

    /// <summary>Returns true if a user has a password set</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> HasPasswordAsync(TUser user);
  }
}
