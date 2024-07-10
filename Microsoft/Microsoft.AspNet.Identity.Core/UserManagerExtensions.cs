// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserManagerExtensions
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
  /// <summary>Extension methods for UserManager</summary>
  public static class UserManagerExtensions
  {
    /// <summary>Creates a ClaimsIdentity representing the user</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="authenticationType"></param>
    /// <returns></returns>
    public static ClaimsIdentity CreateIdentity<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user,
      string authenticationType)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<ClaimsIdentity>((Func<Task<ClaimsIdentity>>) (() => manager.CreateIdentityAsync(user, authenticationType)));
    }

    /// <summary>Find a user by id</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static TUser FindById<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TUser>((Func<Task<TUser>>) (() => manager.FindByIdAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Return a user with the specified username and password or null if there is no match.
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static TUser Find<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      string userName,
      string password)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<TUser>((Func<Task<TUser>>) (() => manager.FindAsync(userName, password)));
    }

    /// <summary>Find a user by name</summary>
    /// <param name="manager"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    public static TUser FindByName<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      string userName)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TUser>((Func<Task<TUser>>) (() => manager.FindByNameAsync(userName))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Find a user by email</summary>
    /// <param name="manager"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public static TUser FindByEmail<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      string email)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TUser>((Func<Task<TUser>>) (() => manager.FindByEmailAsync(email))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Create a user with no password</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IdentityResult Create<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.CreateAsync(user))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Create a user and associates it with the given password (if one is provided)
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static IdentityResult Create<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user,
      string password)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.CreateAsync(user, password)));
    }

    /// <summary>Update an user</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IdentityResult Update<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.UpdateAsync(user))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Delete an user</summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IdentityResult Delete<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.DeleteAsync(user))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Returns true if a user has a password set</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool HasPassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.HasPasswordAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Add a user password only if one does not already exist
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static IdentityResult AddPassword<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string password)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddPasswordAsync(userId, password)));
    }

    /// <summary>Change a user password</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public static IdentityResult ChangePassword<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string currentPassword,
      string newPassword)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.ChangePasswordAsync(userId, currentPassword, newPassword)));
    }

    /// <summary>
    ///     Reset a user's password using a reset password token
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="token">This should be the user's security stamp by default</param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public static IdentityResult ResetPassword<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string token,
      string newPassword)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.ResetPasswordAsync(userId, token, newPassword)));
    }

    /// <summary>Get the password reset token for the user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GeneratePasswordResetToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GeneratePasswordResetTokenAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Get the current security stamp for a user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GetSecurityStamp<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GetSecurityStampAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Get the confirmation token for the user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GenerateEmailConfirmationToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GenerateEmailConfirmationTokenAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Confirm the user with confirmation token</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static IdentityResult ConfirmEmail<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string token)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.ConfirmEmailAsync(userId, token)));
    }

    /// <summary>Returns true if the user's email has been confirmed</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool IsEmailConfirmed<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.IsEmailConfirmedAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Generate a new security stamp for a user, used for SignOutEverywhere functionality
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IdentityResult UpdateSecurityStamp<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.UpdateSecurityStampAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Returns true if the password combination is valid for the user
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool CheckPassword<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TUser user,
      string password)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.CheckPasswordAsync(user, password)));
    }

    /// <summary>Associate a login with a user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IdentityResult RemovePassword<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.RemovePasswordAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Sync extension</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public static IdentityResult AddLogin<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      UserLoginInfo login)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddLoginAsync(userId, login)));
    }

    /// <summary>Remove a user login</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public static IdentityResult RemoveLogin<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      UserLoginInfo login)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.RemoveLoginAsync(userId, login)));
    }

    /// <summary>Gets the logins for a user.</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IList<UserLoginInfo> GetLogins<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IList<UserLoginInfo>>((Func<Task<IList<UserLoginInfo>>>) (() => manager.GetLoginsAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Sync extension</summary>
    /// <param name="manager"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public static TUser Find<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      UserLoginInfo login)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TUser>((Func<Task<TUser>>) (() => manager.FindAsync(login))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Add a user claim</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public static IdentityResult AddClaim<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      Claim claim)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddClaimAsync(userId, claim)));
    }

    /// <summary>Remove a user claim</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public static IdentityResult RemoveClaim<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      Claim claim)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.RemoveClaimAsync(userId, claim)));
    }

    /// <summary>Get a users's claims</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IList<Claim> GetClaims<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IList<Claim>>((Func<Task<IList<Claim>>>) (() => manager.GetClaimsAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Add a user to a role</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IdentityResult AddToRole<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string role)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddToRoleAsync(userId, role)));
    }

    /// <summary>Add a user to several roles</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    public static IdentityResult AddToRoles<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      params string[] roles)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AddToRolesAsync(userId, roles)));
    }

    /// <summary>Remove a user from a role.</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IdentityResult RemoveFromRole<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string role)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.RemoveFromRoleAsync(userId, role)));
    }

    /// <summary>Remove a user from the specified roles.</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    public static IdentityResult RemoveFromRoles<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      params string[] roles)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.RemoveFromRolesAsync(userId, roles)));
    }

    /// <summary>Get a users's roles</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IList<string> GetRoles<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IList<string>>((Func<Task<IList<string>>>) (() => manager.GetRolesAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Returns true if the user is in the specified role</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static bool IsInRole<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string role)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.IsInRoleAsync(userId, role)));
    }

    /// <summary>Get an user's email</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GetEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GetEmailAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Set an user's email</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public static IdentityResult SetEmail<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string email)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.SetEmailAsync(userId, email)));
    }

    /// <summary>Get an user's phoneNumber</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GetPhoneNumber<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GetPhoneNumberAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Set an user's phoneNumber</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static IdentityResult SetPhoneNumber<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string phoneNumber)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.SetPhoneNumberAsync(userId, phoneNumber)));
    }

    /// <summary>Change a phone number using the verification token</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static IdentityResult ChangePhoneNumber<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string phoneNumber,
      string token)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.ChangePhoneNumberAsync(userId, phoneNumber, token)));
    }

    /// <summary>
    ///     Generate a token for using to change to a specific phone number for the user
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static string GenerateChangePhoneNumberToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string phoneNumber)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GenerateChangePhoneNumberTokenAsync(userId, phoneNumber)));
    }

    /// <summary>
    ///     Verify that a token is valid for changing the user's phone number
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static bool VerifyChangePhoneNumberToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string token,
      string phoneNumber)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.VerifyChangePhoneNumberTokenAsync(userId, token, phoneNumber)));
    }

    /// <summary>
    ///     Returns true if the user's phone number has been confirmed
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool IsPhoneNumberConfirmed<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.IsPhoneNumberConfirmedAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Get a user token for a factor provider</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="providerId"></param>
    /// <returns></returns>
    public static string GenerateTwoFactorToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string providerId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GenerateTwoFactorTokenAsync(userId, providerId)));
    }

    /// <summary>
    ///     Verify a user factor token with the specified provider
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="providerId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static bool VerifyTwoFactorToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string providerId,
      string token)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.VerifyTwoFactorTokenAsync(userId, providerId, token)));
    }

    /// <summary>
    ///     Returns a list of valid two factor providers for a user
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IList<string> GetValidTwoFactorProviders<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IList<string>>((Func<Task<IList<string>>>) (() => manager.GetValidTwoFactorProvidersAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Get a user token for a specific purpose</summary>
    /// <param name="manager"></param>
    /// <param name="purpose"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GenerateUserToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      string purpose,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<string>((Func<Task<string>>) (() => manager.GenerateUserTokenAsync(purpose, userId)));
    }

    /// <summary>Validate a user token</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="purpose"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static bool VerifyUserToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string purpose,
      string token)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.VerifyUserTokenAsync(userId, purpose, token)));
    }

    /// <summary>
    ///     Notify a user with a token from a specific user factor provider
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="twoFactorProvider"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static IdentityResult NotifyTwoFactorToken<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string twoFactorProvider,
      string token)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.NotifyTwoFactorTokenAsync(userId, twoFactorProvider, token)));
    }

    /// <summary>Returns true if two factor is enabled for the user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool GetTwoFactorEnabled<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.GetTwoFactorEnabledAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Set whether a user's two factor is enabled</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public static IdentityResult SetTwoFactorEnabled<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      bool enabled)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.SetTwoFactorEnabledAsync(userId, enabled)));
    }

    /// <summary>Send email with supplied subject and body</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    public static void SendEmail<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string subject,
      string body)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AsyncHelper.RunSync((Func<Task>) (() => manager.SendEmailAsync(userId, subject, body)));
    }

    /// <summary>Send text message using the given message</summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="message"></param>
    public static void SendSms<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      string message)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AsyncHelper.RunSync((Func<Task>) (() => manager.SendSmsAsync(userId, message)));
    }

    /// <summary>Returns true if the user is locked out</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool IsLockedOut<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.IsLockedOutAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Sets whether the user allows lockout</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public static IdentityResult SetLockoutEnabled<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      bool enabled)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.SetLockoutEnabledAsync(userId, enabled)));
    }

    /// <summary>Returns whether the user allows lockout</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool GetLockoutEnabled<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.GetLockoutEnabledAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Returns the user lockout end date</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static DateTimeOffset GetLockoutEndDate<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<DateTimeOffset>((Func<Task<DateTimeOffset>>) (() => manager.GetLockoutEndDateAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Sets the user lockout end date</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <param name="lockoutEnd"></param>
    /// <returns></returns>
    public static IdentityResult SetLockoutEndDate<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId,
      DateTimeOffset lockoutEnd)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.SetLockoutEndDateAsync(userId, lockoutEnd)));
    }

    /// <summary>Increments the access failed count for the user</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IdentityResult AccessFailed<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.AccessFailedAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Resets the access failed count for the user to 0</summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static IdentityResult ResetAccessFailedCount<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.ResetAccessFailedCountAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Returns the number of failed access attempts for the user
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static int GetAccessFailedCount<TUser, TKey>(
      this UserManager<TUser, TKey> manager,
      TKey userId)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<int>((Func<Task<int>>) (() => manager.GetAccessFailedCountAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }
  }
}
