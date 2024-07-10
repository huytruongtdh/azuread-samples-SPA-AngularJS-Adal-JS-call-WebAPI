// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserLockoutStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Stores information which can be used to implement account lockout, including access failures and lockout status
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserLockoutStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>
    ///     Returns the DateTimeOffset that represents the end of a user's lockout, any time in the past should be considered
    ///     not locked out.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user);

    /// <summary>
    ///     Locks a user out until the specified end date (set to a past date, to unlock a user)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="lockoutEnd"></param>
    /// <returns></returns>
    Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd);

    /// <summary>
    ///     Used to record when an attempt to access the user has failed
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<int> IncrementAccessFailedCountAsync(TUser user);

    /// <summary>
    ///     Used to reset the access failed count, typically after the account is successfully accessed
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task ResetAccessFailedCountAsync(TUser user);

    /// <summary>
    ///     Returns the current number of failed access attempts.  This number usually will be reset whenever the password is
    ///     verified or the account is locked out.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<int> GetAccessFailedCountAsync(TUser user);

    /// <summary>Returns whether the user can be locked out.</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> GetLockoutEnabledAsync(TUser user);

    /// <summary>Sets whether the user can be locked out.</summary>
    /// <param name="user"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    Task SetLockoutEnabledAsync(TUser user, bool enabled);
  }
}
