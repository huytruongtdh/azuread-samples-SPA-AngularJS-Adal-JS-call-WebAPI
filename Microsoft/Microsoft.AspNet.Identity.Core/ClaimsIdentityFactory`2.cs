// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.ClaimsIdentityFactory`2
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
  /// <summary>Creates a ClaimsIdentity from a User</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class ClaimsIdentityFactory<TUser, TKey> : IClaimsIdentityFactory<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    internal const string IdentityProviderClaimType = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";
    internal const string DefaultIdentityProviderClaimValue = "ASP.NET Identity";

    /// <summary>Constructor</summary>
    public ClaimsIdentityFactory()
    {
      this.RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      this.UserIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
      this.UserNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
      this.SecurityStampClaimType = "AspNet.Identity.SecurityStamp";
    }

    /// <summary>Claim type used for role claims</summary>
    public string RoleClaimType { get; set; }

    /// <summary>Claim type used for the user name</summary>
    public string UserNameClaimType { get; set; }

    /// <summary>Claim type used for the user id</summary>
    public string UserIdClaimType { get; set; }

    /// <summary>Claim type used for the user security stamp</summary>
    public string SecurityStampClaimType { get; set; }

    /// <summary>Create a ClaimsIdentity from a user</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="authenticationType"></param>
    /// <returns></returns>
    public virtual async Task<ClaimsIdentity> CreateAsync(
      UserManager<TUser, TKey> manager,
      TUser user,
      string authenticationType)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      ClaimsIdentity id = new ClaimsIdentity(authenticationType, this.UserNameClaimType, this.RoleClaimType);
      id.AddClaim(new Claim(this.UserIdClaimType, this.ConvertIdToString(user.Id), "http://www.w3.org/2001/XMLSchema#string"));
      id.AddClaim(new Claim(this.UserNameClaimType, user.UserName, "http://www.w3.org/2001/XMLSchema#string"));
      id.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"));
      ClaimsIdentity claimsIdentity;
      if (manager.SupportsUserSecurityStamp)
      {
        claimsIdentity = id;
        string type = this.SecurityStampClaimType;
        claimsIdentity.AddClaim(new Claim(type, await manager.GetSecurityStampAsync(user.Id).WithCurrentCulture<string>()));
        claimsIdentity = (ClaimsIdentity) null;
        type = (string) null;
      }
      if (manager.SupportsUserRole)
      {
        foreach (string str in (IEnumerable<string>) await manager.GetRolesAsync(user.Id).WithCurrentCulture<IList<string>>())
          id.AddClaim(new Claim(this.RoleClaimType, str, "http://www.w3.org/2001/XMLSchema#string"));
      }
      if (manager.SupportsUserClaim)
      {
        claimsIdentity = id;
        claimsIdentity.AddClaims((IEnumerable<Claim>) await manager.GetClaimsAsync(user.Id).WithCurrentCulture<IList<Claim>>());
        claimsIdentity = (ClaimsIdentity) null;
      }
      return id;
    }

    /// <summary>
    ///     Convert the key to a string, by default just calls .ToString()
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public virtual string ConvertIdToString(TKey key) => (object) key != null ? key.ToString() : throw new ArgumentNullException(nameof (key));
  }
}
