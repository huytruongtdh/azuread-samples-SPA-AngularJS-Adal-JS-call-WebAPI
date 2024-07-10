// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.TotpSecurityStampBasedTokenProvider`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     TokenProvider that generates time based codes using the user's security stamp
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class TotpSecurityStampBasedTokenProvider<TUser, TKey> : IUserTokenProvider<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>
    ///     This token provider does not notify the user by default
    /// </summary>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user) => (Task) Task.FromResult<int>(0);

    /// <summary>
    ///     Returns true if the provider can generate tokens for the user, by default this is equal to
    ///     manager.SupportsUserSecurityStamp
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> IsValidProviderForUserAsync(
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      return manager != null ? Task.FromResult<bool>(manager.SupportsUserSecurityStamp) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Generate a token for the user using their security stamp
    /// </summary>
    /// <param name="purpose"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<string> GenerateAsync(
      string purpose,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      SecurityToken token = await manager.CreateSecurityTokenAsync(user.Id).WithCurrentCulture<SecurityToken>();
      return Rfc6238AuthenticationService.GenerateCode(token, await this.GetUserModifierAsync(purpose, manager, user).WithCurrentCulture<string>()).ToString("D6", (IFormatProvider) CultureInfo.InvariantCulture);
    }

    /// <summary>Validate the token for the user</summary>
    /// <param name="purpose"></param>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<bool> ValidateAsync(
      string purpose,
      string token,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      int code;
      if (!int.TryParse(token, out code))
        return false;
      SecurityToken securityToken = await manager.CreateSecurityTokenAsync(user.Id).WithCurrentCulture<SecurityToken>();
      string modifier = await this.GetUserModifierAsync(purpose, manager, user).WithCurrentCulture<string>();
      return securityToken != null && Rfc6238AuthenticationService.ValidateCode(securityToken, code, modifier);
    }

    /// <summary>
    ///     Used for entropy in the token, uses the user.Id by default
    /// </summary>
    /// <param name="purpose"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<string> GetUserModifierAsync(
      string purpose,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      return Task.FromResult<string>("Totp:" + purpose + ":" + (object) user.Id);
    }
  }
}
