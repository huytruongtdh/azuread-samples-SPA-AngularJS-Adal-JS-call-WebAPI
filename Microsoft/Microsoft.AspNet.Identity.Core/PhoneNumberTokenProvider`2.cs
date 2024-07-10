// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.PhoneNumberTokenProvider`2
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
  ///     TokenProvider that generates tokens from the user's security stamp and notifies a user via their phone number
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class PhoneNumberTokenProvider<TUser, TKey> : 
    TotpSecurityStampBasedTokenProvider<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    private string _body;

    /// <summary>
    ///     Message contents which should contain a format string which the token will be the only argument
    /// </summary>
    public string MessageFormat
    {
      get => this._body ?? "{0}";
      set => this._body = value;
    }

    /// <summary>Returns true if the user has a phone number set</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override async Task<bool> IsValidProviderForUserAsync(
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      bool flag = !string.IsNullOrWhiteSpace(await manager.GetPhoneNumberAsync(user.Id).WithCurrentCulture<string>());
      if (flag)
        flag = await manager.IsPhoneNumberConfirmedAsync(user.Id).WithCurrentCulture<bool>();
      return flag;
    }

    /// <summary>
    ///     Returns the phone number of the user for entropy in the token
    /// </summary>
    /// <param name="purpose"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override async Task<string> GetUserModifierAsync(
      string purpose,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return "PhoneNumber:" + purpose + ":" + await manager.GetPhoneNumberAsync(user.Id).WithCurrentCulture<string>();
    }

    /// <summary>
    ///     Notifies the user with a token via sms using the MessageFormat
    /// </summary>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return manager.SendSmsAsync(user.Id, string.Format((IFormatProvider) CultureInfo.CurrentCulture, this.MessageFormat, (object) token));
    }
  }
}
