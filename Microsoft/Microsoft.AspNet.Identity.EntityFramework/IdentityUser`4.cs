﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityUser`4
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>Default EntityFramework IUser implementation</summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TLogin"></typeparam>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TClaim"></typeparam>
  public class IdentityUser<TKey, TLogin, TRole, TClaim> : IUser<TKey>
    where TLogin : IdentityUserLogin<TKey>
    where TRole : IdentityUserRole<TKey>
    where TClaim : IdentityUserClaim<TKey>
  {
    /// <summary>Constructor</summary>
    public IdentityUser()
    {
      this.Claims = (ICollection<TClaim>) new List<TClaim>();
      this.Roles = (ICollection<TRole>) new List<TRole>();
      this.Logins = (ICollection<TLogin>) new List<TLogin>();
    }

    /// <summary>Email</summary>
    public virtual string Email { get; set; }

    /// <summary>True if the email is confirmed, default is false</summary>
    public virtual bool EmailConfirmed { get; set; }

    /// <summary>The salted/hashed form of the user password</summary>
    public virtual string PasswordHash { get; set; }

    /// <summary>
    ///     A random value that should change whenever a users credentials have changed (password changed, login removed)
    /// </summary>
    public virtual string SecurityStamp { get; set; }

    /// <summary>PhoneNumber for the user</summary>
    public virtual string PhoneNumber { get; set; }

    /// <summary>
    ///     True if the phone number is confirmed, default is false
    /// </summary>
    public virtual bool PhoneNumberConfirmed { get; set; }

    /// <summary>Is two factor enabled for the user</summary>
    public virtual bool TwoFactorEnabled { get; set; }

    /// <summary>
    ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
    /// </summary>
    public virtual DateTime? LockoutEndDateUtc { get; set; }

    /// <summary>Is lockout enabled for this user</summary>
    public virtual bool LockoutEnabled { get; set; }

    /// <summary>Used to record failures for the purposes of lockout</summary>
    public virtual int AccessFailedCount { get; set; }

    /// <summary>Navigation property for user roles</summary>
    public virtual ICollection<TRole> Roles { get; private set; }

    /// <summary>Navigation property for user claims</summary>
    public virtual ICollection<TClaim> Claims { get; private set; }

    /// <summary>Navigation property for user logins</summary>
    public virtual ICollection<TLogin> Logins { get; private set; }

    /// <summary>User ID (Primary Key)</summary>
    public virtual TKey Id { get; set; }

    /// <summary>User name</summary>
    public virtual string UserName { get; set; }
  }
}
