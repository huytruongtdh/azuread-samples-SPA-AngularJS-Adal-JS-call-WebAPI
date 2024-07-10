// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EmailTokenProvider`2
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
  ///     TokenProvider that generates tokens from the user's security stamp and notifies a user via their email
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class EmailTokenProvider<TUser, TKey> : TotpSecurityStampBasedTokenProvider<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    private string _body;
    private string _subject;

    /// <summary>
    ///     Email subject used when a token notification is received
    /// </summary>
    public string Subject
    {
      get => this._subject ?? string.Empty;
      set => this._subject = value;
    }

    /// <summary>
    ///     Email body which should contain a formatted string which the token will be the only argument
    /// </summary>
    public string BodyFormat
    {
      get => this._body ?? "{0}";
      set => this._body = value;
    }

    /// <summary>True if the user has an email set</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override async Task<bool> IsValidProviderForUserAsync(
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      bool flag = !string.IsNullOrWhiteSpace(await manager.GetEmailAsync(user.Id).WithCurrentCulture<string>());
      if (flag)
        flag = await manager.IsEmailConfirmedAsync(user.Id).WithCurrentCulture<bool>();
      return flag;
    }

    /// <summary>
    ///     Returns the email of the user for entropy in the token
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
      return "Email:" + purpose + ":" + await manager.GetEmailAsync(user.Id).WithCurrentCulture<string>();
    }

    /// <summary>
    ///     Notifies the user with a token via email using the Subject and BodyFormat
    /// </summary>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return manager.SendEmailAsync(user.Id, this.Subject, string.Format((IFormatProvider) CultureInfo.CurrentCulture, this.BodyFormat, (object) token));
    }
  }
}
