// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserTwoFactorStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Stores whether two factor authentication is enabled for a user
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserTwoFactorStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>
    ///     Sets whether two factor authentication is enabled for the user
    /// </summary>
    /// <param name="user"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    Task SetTwoFactorEnabledAsync(TUser user, bool enabled);

    /// <summary>
    ///     Returns whether two factor authentication is enabled for the user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> GetTwoFactorEnabledAsync(TUser user);
  }
}
