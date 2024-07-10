// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserEmailStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Stores a user's email</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserEmailStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Set the user email</summary>
    /// <param name="user"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    Task SetEmailAsync(TUser user, string email);

    /// <summary>Get the user email</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> GetEmailAsync(TUser user);

    /// <summary>Returns true if the user email is confirmed</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> GetEmailConfirmedAsync(TUser user);

    /// <summary>Sets whether the user email is confirmed</summary>
    /// <param name="user"></param>
    /// <param name="confirmed"></param>
    /// <returns></returns>
    Task SetEmailConfirmedAsync(TUser user, bool confirmed);

    /// <summary>Returns the user associated with this email</summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<TUser> FindByEmailAsync(string email);
  }
}
