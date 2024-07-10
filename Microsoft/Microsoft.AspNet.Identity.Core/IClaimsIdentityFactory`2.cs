// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IClaimsIdentityFactory`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Interface for creating a ClaimsIdentity from an IUser
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IClaimsIdentityFactory<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>
    ///     Create a ClaimsIdentity from an user using a UserManager
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="authenticationType"></param>
    /// <returns></returns>
    Task<ClaimsIdentity> CreateAsync(
      UserManager<TUser, TKey> manager,
      TUser user,
      string authenticationType);
  }
}
