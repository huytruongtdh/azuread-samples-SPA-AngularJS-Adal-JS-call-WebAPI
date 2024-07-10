// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserValidator`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Validates users before they are saved</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class UserValidator<TUser, TKey> : IIdentityValidator<TUser>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>Constructor</summary>
    /// <param name="manager"></param>
    public UserValidator(UserManager<TUser, TKey> manager)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      this.AllowOnlyAlphanumericUserNames = true;
      this.Manager = manager;
    }

    /// <summary>Only allow [A-Za-z0-9@_] in UserNames</summary>
    public bool AllowOnlyAlphanumericUserNames { get; set; }

    /// <summary>
    ///     If set, enforces that emails are non empty, valid, and unique
    /// </summary>
    public bool RequireUniqueEmail { get; set; }

    private UserManager<TUser, TKey> Manager { get; set; }

    /// <summary>Validates a user before saving</summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ValidateAsync(TUser item)
    {
      if ((object) item == null)
        throw new ArgumentNullException(nameof (item));
      List<string> errors = new List<string>();
      await this.ValidateUserName(item, errors).WithCurrentCulture();
      if (this.RequireUniqueEmail)
        await this.ValidateEmailAsync(item, errors).WithCurrentCulture();
      return errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
    }

    private async Task ValidateUserName(TUser user, List<string> errors)
    {
      if (string.IsNullOrWhiteSpace(user.UserName))
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.PropertyTooShort, (object) "Name"));
      else if (this.AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, "^[A-Za-z0-9@_\\.]+$"))
      {
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.InvalidUserName, (object) user.UserName));
      }
      else
      {
        TUser user1 = await this.Manager.FindByNameAsync(user.UserName).WithCurrentCulture<TUser>();
        if ((object) user1 == null || EqualityComparer<TKey>.Default.Equals(user1.Id, user.Id))
          return;
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.DuplicateName, (object) user.UserName));
      }
    }

    private async Task ValidateEmailAsync(TUser user, List<string> errors)
    {
      string email = await this.Manager.GetEmailStore().GetEmailAsync(user).WithCurrentCulture<string>();
      if (string.IsNullOrWhiteSpace(email))
      {
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.PropertyTooShort, (object) "Email"));
      }
      else
      {
        try
        {
          MailAddress mailAddress = new MailAddress(email);
        }
        catch (FormatException ex)
        {
          errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.InvalidEmail, (object) email));
          return;
        }
        TUser user1 = await this.Manager.FindByEmailAsync(email).WithCurrentCulture<TUser>();
        if ((object) user1 == null || EqualityComparer<TKey>.Default.Equals(user1.Id, user.Id))
          return;
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.DuplicateEmail, (object) email));
      }
    }
  }
}
