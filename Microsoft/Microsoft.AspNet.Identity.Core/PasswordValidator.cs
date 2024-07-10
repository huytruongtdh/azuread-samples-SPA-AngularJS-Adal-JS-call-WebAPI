// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.PasswordValidator
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Used to validate some basic password policy like length and number of non alphanumerics
  /// </summary>
  public class PasswordValidator : IIdentityValidator<string>
  {
    /// <summary>Minimum required length</summary>
    public int RequiredLength { get; set; }

    /// <summary>Require a non letter or digit character</summary>
    public bool RequireNonLetterOrDigit { get; set; }

    /// <summary>Require a lower case letter ('a' - 'z')</summary>
    public bool RequireLowercase { get; set; }

    /// <summary>Require an upper case letter ('A' - 'Z')</summary>
    public bool RequireUppercase { get; set; }

    /// <summary>Require a digit ('0' - '9')</summary>
    public bool RequireDigit { get; set; }

    /// <summary>
    ///     Ensures that the string is of the required length and meets the configured requirements
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual Task<IdentityResult> ValidateAsync(string item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof (item));
      List<string> values = new List<string>();
      if (string.IsNullOrWhiteSpace(item) || item.Length < this.RequiredLength)
        values.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.PasswordTooShort, (object) this.RequiredLength));
      if (this.RequireNonLetterOrDigit && item.All<char>(new Func<char, bool>(this.IsLetterOrDigit)))
        values.Add(Resources.PasswordRequireNonLetterOrDigit);
      if (this.RequireDigit && item.All<char>((Func<char, bool>) (c => !this.IsDigit(c))))
        values.Add(Resources.PasswordRequireDigit);
      if (this.RequireLowercase && item.All<char>((Func<char, bool>) (c => !this.IsLower(c))))
        values.Add(Resources.PasswordRequireLower);
      if (this.RequireUppercase && item.All<char>((Func<char, bool>) (c => !this.IsUpper(c))))
        values.Add(Resources.PasswordRequireUpper);
      if (values.Count == 0)
        return Task.FromResult<IdentityResult>(IdentityResult.Success);
      return Task.FromResult<IdentityResult>(IdentityResult.Failed(string.Join(" ", (IEnumerable<string>) values)));
    }

    /// <summary>
    ///     Returns true if the character is a digit between '0' and '9'
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public virtual bool IsDigit(char c) => c >= '0' && c <= '9';

    /// <summary>
    ///     Returns true if the character is between 'a' and 'z'
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public virtual bool IsLower(char c) => c >= 'a' && c <= 'z';

    /// <summary>
    ///     Returns true if the character is between 'A' and 'Z'
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public virtual bool IsUpper(char c) => c >= 'A' && c <= 'Z';

    /// <summary>
    ///     Returns true if the character is upper, lower, or a digit
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public virtual bool IsLetterOrDigit(char c) => this.IsUpper(c) || this.IsLower(c) || this.IsDigit(c);
  }
}
