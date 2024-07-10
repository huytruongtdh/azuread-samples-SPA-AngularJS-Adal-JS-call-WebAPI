// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.RoleValidator`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Validates roles before they are saved</summary>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class RoleValidator<TRole, TKey> : IIdentityValidator<TRole>
    where TRole : class, IRole<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>Constructor</summary>
    /// <param name="manager"></param>
    public RoleValidator(RoleManager<TRole, TKey> manager) => this.Manager = manager != null ? manager : throw new ArgumentNullException(nameof (manager));

    private RoleManager<TRole, TKey> Manager { get; set; }

    /// <summary>Validates a role before saving</summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ValidateAsync(TRole item)
    {
      if ((object) item == null)
        throw new ArgumentNullException(nameof (item));
      List<string> errors = new List<string>();
      await this.ValidateRoleName(item, errors).WithCurrentCulture();
      return errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
    }

    private async Task ValidateRoleName(TRole role, List<string> errors)
    {
      if (string.IsNullOrWhiteSpace(role.Name))
      {
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.PropertyTooShort, (object) "Name"));
      }
      else
      {
        TRole role1 = await this.Manager.FindByNameAsync(role.Name).WithCurrentCulture<TRole>();
        if ((object) role1 == null || EqualityComparer<TKey>.Default.Equals(role1.Id, role.Id))
          return;
        errors.Add(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.DuplicateName, (object) role.Name));
      }
    }
  }
}
