// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUserPhoneNumberStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Stores a user's phone number</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IUserPhoneNumberStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>Set the user's phone number</summary>
    /// <param name="user"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    Task SetPhoneNumberAsync(TUser user, string phoneNumber);

    /// <summary>Get the user phone number</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<string> GetPhoneNumberAsync(TUser user);

    /// <summary>Returns true if the user phone number is confirmed</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> GetPhoneNumberConfirmedAsync(TUser user);

    /// <summary>Sets whether the user phone number is confirmed</summary>
    /// <param name="user"></param>
    /// <param name="confirmed"></param>
    /// <returns></returns>
    Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed);
  }
}
