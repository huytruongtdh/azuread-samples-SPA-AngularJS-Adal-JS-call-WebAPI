﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserTokenProvider`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface to generate user tokens</summary>
  public interface IUserTokenProvider<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>Generate a token for a user with a specific purpose</summary>
    /// <param name="purpose"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> GenerateAsync(string purpose, UserManager<TUser, TKey> manager, TUser user);

    /// <summary>Validate a token for a user with a specific purpose</summary>
    /// <param name="purpose"></param>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> ValidateAsync(
      string purpose,
      string token,
      UserManager<TUser, TKey> manager,
      TUser user);

    /// <summary>
    ///     Notifies the user that a token has been generated, for example an email or sms could be sent, or
    ///     this can be a no-op
    /// </summary>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user);

    /// <summary>
    ///     Returns true if provider can be used for this user, i.e. could require a user to have an email
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> IsValidProviderForUserAsync(UserManager<TUser, TKey> manager, TUser user);
  }
}
