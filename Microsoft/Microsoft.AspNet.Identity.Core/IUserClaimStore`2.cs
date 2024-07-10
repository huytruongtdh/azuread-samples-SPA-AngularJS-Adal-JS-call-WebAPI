﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserClaimStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Stores user specific claims</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserClaimStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Returns the claims for the user with the issuer set</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<IList<Claim>> GetClaimsAsync(TUser user);

    /// <summary>Add a new user claim</summary>
    /// <param name="user"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    Task AddClaimAsync(TUser user, Claim claim);

    /// <summary>Remove a user claim</summary>
    /// <param name="user"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    Task RemoveClaimAsync(TUser user, Claim claim);
  }
}
