// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IClaimsIdentityFactory`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface for creating a ClaimsIdentity from a user</summary>
  /// <typeparam name="TUser"></typeparam>
  public interface IClaimsIdentityFactory<TUser> where TUser : class, IUser
  {
    /// <summary>
    ///     Create a ClaimsIdentity from an user using a UserManager
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="authenticationType"></param>
    /// <returns></returns>
    Task<ClaimsIdentity> CreateAsync(
      UserManager<TUser> manager,
      TUser user,
      string authenticationType);
  }
}
