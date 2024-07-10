// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.MinimumLengthValidator
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
  ///     Used to validate that passwords are a minimum length
  /// </summary>
  public class MinimumLengthValidator : IIdentityValidator<string>
  {
    /// <summary>Constructor</summary>
    /// <param name="requiredLength"></param>
    public MinimumLengthValidator(int requiredLength) => this.RequiredLength = requiredLength;

    /// <summary>Minimum required length for the password</summary>
    public int RequiredLength { get; set; }

    /// <summary>Ensures that the password is of the required length</summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual Task<IdentityResult> ValidateAsync(string item)
    {
      if (!string.IsNullOrWhiteSpace(item) && item.Length >= this.RequiredLength)
        return Task.FromResult<IdentityResult>(IdentityResult.Success);
      return Task.FromResult<IdentityResult>(IdentityResult.Failed(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.PasswordTooShort, (object) this.RequiredLength)));
    }
  }
}
