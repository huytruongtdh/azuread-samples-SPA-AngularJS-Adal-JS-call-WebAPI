// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserManager`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Exposes user related api which will automatically save changes to the UserStore
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class UserManager<TUser, TKey> : IDisposable
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    private readonly Dictionary<string, IUserTokenProvider<TUser, TKey>> _factors = new Dictionary<string, IUserTokenProvider<TUser, TKey>>();
    private IClaimsIdentityFactory<TUser, TKey> _claimsFactory;
    private TimeSpan _defaultLockout = TimeSpan.Zero;
    private bool _disposed;
    private IPasswordHasher _passwordHasher;
    private IIdentityValidator<string> _passwordValidator;
    private IIdentityValidator<TUser> _userValidator;

    /// <summary>Constructor</summary>
    /// <param name="store">The IUserStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods</param>
    public UserManager(IUserStore<TUser, TKey> store)
    {
      this.Store = store != null ? store : throw new ArgumentNullException(nameof (store));
      this.UserValidator = (IIdentityValidator<TUser>) new Microsoft.AspNet.Identity.UserValidator<TUser, TKey>(this);
      this.PasswordValidator = (IIdentityValidator<string>) new MinimumLengthValidator(6);
      this.PasswordHasher = (IPasswordHasher) new Microsoft.AspNet.Identity.PasswordHasher();
      this.ClaimsIdentityFactory = (IClaimsIdentityFactory<TUser, TKey>) new Microsoft.AspNet.Identity.ClaimsIdentityFactory<TUser, TKey>();
    }

    /// <summary>
    ///     Persistence abstraction that the UserManager operates against
    /// </summary>
    protected internal IUserStore<TUser, TKey> Store { get; set; }

    /// <summary>Used to hash/verify passwords</summary>
    public IPasswordHasher PasswordHasher
    {
      get
      {
        this.ThrowIfDisposed();
        return this._passwordHasher;
      }
      set
      {
        this.ThrowIfDisposed();
        this._passwordHasher = value != null ? value : throw new ArgumentNullException(nameof (value));
      }
    }

    /// <summary>Used to validate users before changes are saved</summary>
    public IIdentityValidator<TUser> UserValidator
    {
      get
      {
        this.ThrowIfDisposed();
        return this._userValidator;
      }
      set
      {
        this.ThrowIfDisposed();
        this._userValidator = value != null ? value : throw new ArgumentNullException(nameof (value));
      }
    }

    /// <summary>
    ///     Used to validate passwords before persisting changes
    /// </summary>
    public IIdentityValidator<string> PasswordValidator
    {
      get
      {
        this.ThrowIfDisposed();
        return this._passwordValidator;
      }
      set
      {
        this.ThrowIfDisposed();
        this._passwordValidator = value != null ? value : throw new ArgumentNullException(nameof (value));
      }
    }

    /// <summary>Used to create claims identities from users</summary>
    public IClaimsIdentityFactory<TUser, TKey> ClaimsIdentityFactory
    {
      get
      {
        this.ThrowIfDisposed();
        return this._claimsFactory;
      }
      set
      {
        this.ThrowIfDisposed();
        this._claimsFactory = value != null ? value : throw new ArgumentNullException(nameof (value));
      }
    }

    /// <summary>Used to send email</summary>
    public IIdentityMessageService EmailService { get; set; }

    /// <summary>Used to send a sms message</summary>
    public IIdentityMessageService SmsService { get; set; }

    /// <summary>
    ///     Used for generating reset password and confirmation tokens
    /// </summary>
    public IUserTokenProvider<TUser, TKey> UserTokenProvider { get; set; }

    /// <summary>
    ///     If true, will enable user lockout when users are created
    /// </summary>
    public bool UserLockoutEnabledByDefault { get; set; }

    /// <summary>
    ///     Number of access attempts allowed before a user is locked out (if lockout is enabled)
    /// </summary>
    public int MaxFailedAccessAttemptsBeforeLockout { get; set; }

    /// <summary>
    ///     Default amount of time that a user is locked out for after MaxFailedAccessAttemptsBeforeLockout is reached
    /// </summary>
    public TimeSpan DefaultAccountLockoutTimeSpan
    {
      get => this._defaultLockout;
      set => this._defaultLockout = value;
    }

    /// <summary>Returns true if the store is an IUserTwoFactorStore</summary>
    public virtual bool SupportsUserTwoFactor
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserTwoFactorStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserPasswordStore</summary>
    public virtual bool SupportsUserPassword
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserPasswordStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserSecurityStore</summary>
    public virtual bool SupportsUserSecurityStamp
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserSecurityStampStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserRoleStore</summary>
    public virtual bool SupportsUserRole
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserRoleStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserLoginStore</summary>
    public virtual bool SupportsUserLogin
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserLoginStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserEmailStore</summary>
    public virtual bool SupportsUserEmail
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserEmailStore<TUser, TKey>;
      }
    }

    /// <summary>
    ///     Returns true if the store is an IUserPhoneNumberStore
    /// </summary>
    public virtual bool SupportsUserPhoneNumber
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserPhoneNumberStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserClaimStore</summary>
    public virtual bool SupportsUserClaim
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserClaimStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IUserLockoutStore</summary>
    public virtual bool SupportsUserLockout
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IUserLockoutStore<TUser, TKey>;
      }
    }

    /// <summary>Returns true if the store is an IQueryableUserStore</summary>
    public virtual bool SupportsQueryableUsers
    {
      get
      {
        this.ThrowIfDisposed();
        return this.Store is IQueryableUserStore<TUser, TKey>;
      }
    }

    /// <summary>
    ///     Returns an IQueryable of users if the store is an IQueryableUserStore
    /// </summary>
    public virtual IQueryable<TUser> Users => this.Store is IQueryableUserStore<TUser, TKey> store ? store.Users : throw new NotSupportedException(Resources.StoreNotIQueryableUserStore);

    /// <summary>
    /// Maps the registered two-factor authentication providers for users by their id
    /// </summary>
    public IDictionary<string, IUserTokenProvider<TUser, TKey>> TwoFactorProviders => (IDictionary<string, IUserTokenProvider<TUser, TKey>>) this._factors;

    /// <summary>Dispose this object</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>Creates a ClaimsIdentity representing the user</summary>
    /// <param name="user"></param>
    /// <param name="authenticationType"></param>
    /// <returns></returns>
    public virtual Task<ClaimsIdentity> CreateIdentityAsync(TUser user, string authenticationType)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      return this.ClaimsIdentityFactory.CreateAsync(this, user, authenticationType);
    }

    /// <summary>Create a user with no password</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> CreateAsync(TUser user)
    {
      this.ThrowIfDisposed();
      await this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      IdentityResult async = await this.UserValidator.ValidateAsync(user).WithCurrentCulture<IdentityResult>();
      if (!async.Succeeded)
        return async;
      if (this.UserLockoutEnabledByDefault && this.SupportsUserLockout)
        await this.GetUserLockoutStore().SetLockoutEnabledAsync(user, true).WithCurrentCulture();
      await this.Store.CreateAsync(user).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Update a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> UpdateAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      IdentityResult identityResult = await this.UserValidator.ValidateAsync(user).WithCurrentCulture<IdentityResult>();
      if (!identityResult.Succeeded)
        return identityResult;
      await this.Store.UpdateAsync(user).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Delete a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> DeleteAsync(TUser user)
    {
      this.ThrowIfDisposed();
      await this.Store.DeleteAsync(user).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Find a user by id</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByIdAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      return this.Store.FindByIdAsync(userId);
    }

    /// <summary>Find a user by user name</summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByNameAsync(string userName)
    {
      this.ThrowIfDisposed();
      return userName != null ? this.Store.FindByNameAsync(userName) : throw new ArgumentNullException(nameof (userName));
    }

    private IUserPasswordStore<TUser, TKey> GetPasswordStore() => this.Store is IUserPasswordStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserPasswordStore);

    /// <summary>Create a user with the given password</summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> CreateAsync(TUser user, string password)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (password == null)
        throw new ArgumentNullException(nameof (password));
      IdentityResult identityResult = await this.UpdatePassword(passwordStore, user, password).WithCurrentCulture<IdentityResult>();
      return !identityResult.Succeeded ? identityResult : await this.CreateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>
    ///     Return a user with the specified username and password or null if there is no match.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual async Task<TUser> FindAsync(string userName, string password)
    {
      this.ThrowIfDisposed();
      TUser user = await this.FindByNameAsync(userName).WithCurrentCulture<TUser>();
      return (object) user == null ? default (TUser) : (await this.CheckPasswordAsync(user, password).WithCurrentCulture<bool>() ? user : default (TUser));
    }

    /// <summary>Returns true if the password is valid for the user</summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual async Task<bool> CheckPasswordAsync(TUser user, string password)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      return (object) user != null && await this.VerifyPasswordAsync(passwordStore, user, password).WithCurrentCulture<bool>();
    }

    /// <summary>Returns true if the user has a password</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> HasPasswordAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await passwordStore.HasPasswordAsync(user).WithCurrentCulture<bool>();
    }

    /// <summary>
    ///     Add a user password only if one does not already exist
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AddPasswordAsync(TKey userId, string password)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (await passwordStore.GetPasswordHashAsync(user).WithCurrentCulture<string>() != null)
        return new IdentityResult(new string[1]
        {
          Resources.UserAlreadyHasPassword
        });
      IdentityResult identityResult = await this.UpdatePassword(passwordStore, user, password).WithCurrentCulture<IdentityResult>();
      return !identityResult.Succeeded ? identityResult : await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Change a user password</summary>
    /// <param name="userId"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ChangePasswordAsync(
      TKey userId,
      string currentPassword,
      string newPassword)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (await this.VerifyPasswordAsync(passwordStore, user, currentPassword).WithCurrentCulture<bool>())
      {
        IdentityResult identityResult = await this.UpdatePassword(passwordStore, user, newPassword).WithCurrentCulture<IdentityResult>();
        return !identityResult.Succeeded ? identityResult : await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
      }
      return IdentityResult.Failed(Resources.PasswordMismatch);
    }

    /// <summary>Remove a user's password</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> RemovePasswordAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserPasswordStore<TUser, TKey> passwordStore = this.GetPasswordStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      await passwordStore.SetPasswordHashAsync(user, (string) null).WithCurrentCulture();
      await this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    protected virtual async Task<IdentityResult> UpdatePassword(
      IUserPasswordStore<TUser, TKey> passwordStore,
      TUser user,
      string newPassword)
    {
      IdentityResult identityResult = await this.PasswordValidator.ValidateAsync(newPassword).WithCurrentCulture<IdentityResult>();
      if (!identityResult.Succeeded)
        return identityResult;
      await passwordStore.SetPasswordHashAsync(user, this.PasswordHasher.HashPassword(newPassword)).WithCurrentCulture();
      await this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>
    ///     By default, retrieves the hashed password from the user store and calls PasswordHasher.VerifyHashPassword
    /// </summary>
    /// <param name="store"></param>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    protected virtual async Task<bool> VerifyPasswordAsync(
      IUserPasswordStore<TUser, TKey> store,
      TUser user,
      string password)
    {
      return this.PasswordHasher.VerifyHashedPassword(await store.GetPasswordHashAsync(user).WithCurrentCulture<string>(), password) != 0;
    }

    private IUserSecurityStampStore<TUser, TKey> GetSecurityStore() => this.Store is IUserSecurityStampStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserSecurityStampStore);

    /// <summary>Returns the current security stamp for a user</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<string> GetSecurityStampAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserSecurityStampStore<TUser, TKey> securityStore = this.GetSecurityStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await securityStore.GetSecurityStampAsync(user).WithCurrentCulture<string>();
    }

    /// <summary>
    ///     Generate a new security stamp for a user, used for SignOutEverywhere functionality
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> UpdateSecurityStampAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserSecurityStampStore<TUser, TKey> securityStore = this.GetSecurityStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      await securityStore.SetSecurityStampAsync(user, UserManager<TUser, TKey>.NewSecurityStamp()).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>
    ///     Generate a password reset token for the user using the UserTokenProvider
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual Task<string> GeneratePasswordResetTokenAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      return this.GenerateUserTokenAsync("ResetPassword", userId);
    }

    /// <summary>
    ///     Reset a user's password using a reset password token
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ResetPasswordAsync(
      TKey userId,
      string token,
      string newPassword)
    {
      this.ThrowIfDisposed();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!await this.VerifyUserTokenAsync(userId, "ResetPassword", token).WithCurrentCulture<bool>())
        return IdentityResult.Failed(Resources.InvalidToken);
      IdentityResult identityResult = await this.UpdatePassword(this.GetPasswordStore(), user, newPassword).WithCurrentCulture<IdentityResult>();
      return !identityResult.Succeeded ? identityResult : await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    internal async Task UpdateSecurityStampInternal(TUser user)
    {
      if (!this.SupportsUserSecurityStamp)
        return;
      await this.GetSecurityStore().SetSecurityStampAsync(user, UserManager<TUser, TKey>.NewSecurityStamp()).WithCurrentCulture();
    }

    private static string NewSecurityStamp() => Guid.NewGuid().ToString();

    private IUserLoginStore<TUser, TKey> GetLoginStore() => this.Store is IUserLoginStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserLoginStore);

    /// <summary>Returns the user associated with this login</summary>
    /// <returns></returns>
    public virtual Task<TUser> FindAsync(UserLoginInfo login)
    {
      this.ThrowIfDisposed();
      return this.GetLoginStore().FindAsync(login);
    }

    /// <summary>Remove a user login</summary>
    /// <param name="userId"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> RemoveLoginAsync(TKey userId, UserLoginInfo login)
    {
      this.ThrowIfDisposed();
      IUserLoginStore<TUser, TKey> loginStore = this.GetLoginStore();
      if (login == null)
        throw new ArgumentNullException(nameof (login));
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      TaskExtensions.CultureAwaiter cultureAwaiter = loginStore.RemoveLoginAsync(user, login).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      await cultureAwaiter;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Associate a login with a user</summary>
    /// <param name="userId"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AddLoginAsync(TKey userId, UserLoginInfo login)
    {
      this.ThrowIfDisposed();
      IUserLoginStore<TUser, TKey> loginStore = this.GetLoginStore();
      if (login == null)
        throw new ArgumentNullException(nameof (login));
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if ((object) await this.FindAsync(login).WithCurrentCulture<TUser>() != null)
        return IdentityResult.Failed(Resources.ExternalLoginExists);
      await loginStore.AddLoginAsync(user, login).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Gets the logins for a user.</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLoginStore<TUser, TKey> loginStore = this.GetLoginStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await loginStore.GetLoginsAsync(user).WithCurrentCulture<IList<UserLoginInfo>>();
    }

    private IUserClaimStore<TUser, TKey> GetClaimStore() => this.Store is IUserClaimStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserClaimStore);

    /// <summary>Add a user claim</summary>
    /// <param name="userId"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AddClaimAsync(TKey userId, Claim claim)
    {
      this.ThrowIfDisposed();
      IUserClaimStore<TUser, TKey> claimStore = this.GetClaimStore();
      if (claim == null)
        throw new ArgumentNullException(nameof (claim));
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      await claimStore.AddClaimAsync(user, claim).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Remove a user claim</summary>
    /// <param name="userId"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> RemoveClaimAsync(TKey userId, Claim claim)
    {
      this.ThrowIfDisposed();
      IUserClaimStore<TUser, TKey> claimStore = this.GetClaimStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      await claimStore.RemoveClaimAsync(user, claim).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Get a users's claims</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IList<Claim>> GetClaimsAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserClaimStore<TUser, TKey> claimStore = this.GetClaimStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await claimStore.GetClaimsAsync(user).WithCurrentCulture<IList<Claim>>();
    }

    private IUserRoleStore<TUser, TKey> GetUserRoleStore() => this.Store is IUserRoleStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserRoleStore);

    /// <summary>Add a user to a role</summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AddToRoleAsync(TKey userId, string role)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if ((await userRoleStore.GetRolesAsync(user).WithCurrentCulture<IList<string>>()).Contains(role))
        return new IdentityResult(new string[1]
        {
          Resources.UserAlreadyInRole
        });
      await userRoleStore.AddToRoleAsync(user, role).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Method to add user to multiple roles</summary>
    /// <param name="userId">user id</param>
    /// <param name="roles">list of role names</param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AddToRolesAsync(TKey userId, params string[] roles)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      if (roles == null)
        throw new ArgumentNullException(nameof (roles));
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      IList<string> userRoles = await userRoleStore.GetRolesAsync(user).WithCurrentCulture<IList<string>>();
      string[] strArray = roles;
      for (int index = 0; index < strArray.Length; ++index)
      {
        string roleName = strArray[index];
        if (userRoles.Contains(roleName))
          return new IdentityResult(new string[1]
          {
            Resources.UserAlreadyInRole
          });
        await userRoleStore.AddToRoleAsync(user, roleName).WithCurrentCulture();
      }
      strArray = (string[]) null;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Remove user from multiple roles</summary>
    /// <param name="userId">user id</param>
    /// <param name="roles">list of role names</param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> RemoveFromRolesAsync(
      TKey userId,
      params string[] roles)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      if (roles == null)
        throw new ArgumentNullException(nameof (roles));
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      IList<string> userRoles = await userRoleStore.GetRolesAsync(user).WithCurrentCulture<IList<string>>();
      string[] strArray = roles;
      for (int index = 0; index < strArray.Length; ++index)
      {
        string roleName = strArray[index];
        if (!userRoles.Contains(roleName))
          return new IdentityResult(new string[1]
          {
            Resources.UserNotInRole
          });
        await userRoleStore.RemoveFromRoleAsync(user, roleName).WithCurrentCulture();
      }
      strArray = (string[]) null;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Remove a user from a role.</summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> RemoveFromRoleAsync(TKey userId, string role)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!await userRoleStore.IsInRoleAsync(user, role).WithCurrentCulture<bool>())
        return new IdentityResult(new string[1]
        {
          Resources.UserNotInRole
        });
      await userRoleStore.RemoveFromRoleAsync(user, role).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Returns the roles for the user</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IList<string>> GetRolesAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await userRoleStore.GetRolesAsync(user).WithCurrentCulture<IList<string>>();
    }

    /// <summary>Returns true if the user is in the specified role</summary>
    /// <param name="userId"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsInRoleAsync(TKey userId, string role)
    {
      this.ThrowIfDisposed();
      IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await userRoleStore.IsInRoleAsync(user, role).WithCurrentCulture<bool>();
    }

    internal IUserEmailStore<TUser, TKey> GetEmailStore() => this.Store is IUserEmailStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserEmailStore);

    /// <summary>Get a user's email</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<string> GetEmailAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserEmailStore<TUser, TKey> store = this.GetEmailStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetEmailAsync(user).WithCurrentCulture<string>();
    }

    /// <summary>Set a user's email</summary>
    /// <param name="userId"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> SetEmailAsync(TKey userId, string email)
    {
      this.ThrowIfDisposed();
      IUserEmailStore<TUser, TKey> store = this.GetEmailStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      TaskExtensions.CultureAwaiter cultureAwaiter = store.SetEmailAsync(user, email).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = store.SetEmailConfirmedAsync(user, false).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      await cultureAwaiter;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Find a user by his email</summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByEmailAsync(string email)
    {
      this.ThrowIfDisposed();
      IUserEmailStore<TUser, TKey> emailStore = this.GetEmailStore();
      string email1 = email != null ? email : throw new ArgumentNullException(nameof (email));
      return emailStore.FindByEmailAsync(email1);
    }

    /// <summary>Get the email confirmation token for the user</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual Task<string> GenerateEmailConfirmationTokenAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      return this.GenerateUserTokenAsync("Confirmation", userId);
    }

    /// <summary>Confirm the user's email with confirmation token</summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ConfirmEmailAsync(TKey userId, string token)
    {
      this.ThrowIfDisposed();
      IUserEmailStore<TUser, TKey> store = this.GetEmailStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!await this.VerifyUserTokenAsync(userId, "Confirmation", token).WithCurrentCulture<bool>())
        return IdentityResult.Failed(Resources.InvalidToken);
      await store.SetEmailConfirmedAsync(user, true).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Returns true if the user's email has been confirmed</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsEmailConfirmedAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserEmailStore<TUser, TKey> store = this.GetEmailStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetEmailConfirmedAsync(user).WithCurrentCulture<bool>();
    }

    internal IUserPhoneNumberStore<TUser, TKey> GetPhoneNumberStore() => this.Store is IUserPhoneNumberStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserPhoneNumberStore);

    /// <summary>Get a user's phoneNumber</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<string> GetPhoneNumberAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserPhoneNumberStore<TUser, TKey> store = this.GetPhoneNumberStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetPhoneNumberAsync(user).WithCurrentCulture<string>();
    }

    /// <summary>Set a user's phoneNumber</summary>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> SetPhoneNumberAsync(TKey userId, string phoneNumber)
    {
      this.ThrowIfDisposed();
      IUserPhoneNumberStore<TUser, TKey> store = this.GetPhoneNumberStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      TaskExtensions.CultureAwaiter cultureAwaiter = store.SetPhoneNumberAsync(user, phoneNumber).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = store.SetPhoneNumberConfirmedAsync(user, false).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      await cultureAwaiter;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>
    ///     Set a user's phoneNumber with the verification token
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ChangePhoneNumberAsync(
      TKey userId,
      string phoneNumber,
      string token)
    {
      this.ThrowIfDisposed();
      IUserPhoneNumberStore<TUser, TKey> store = this.GetPhoneNumberStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (await this.VerifyChangePhoneNumberTokenAsync(userId, token, phoneNumber).WithCurrentCulture<bool>())
      {
        TaskExtensions.CultureAwaiter cultureAwaiter = store.SetPhoneNumberAsync(user, phoneNumber).WithCurrentCulture();
        await cultureAwaiter;
        cultureAwaiter = store.SetPhoneNumberConfirmedAsync(user, true).WithCurrentCulture();
        await cultureAwaiter;
        cultureAwaiter = this.UpdateSecurityStampInternal(user).WithCurrentCulture();
        await cultureAwaiter;
        return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
      }
      return IdentityResult.Failed(Resources.InvalidToken);
    }

    /// <summary>
    ///     Returns true if the user's phone number has been confirmed
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsPhoneNumberConfirmedAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserPhoneNumberStore<TUser, TKey> store = this.GetPhoneNumberStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetPhoneNumberConfirmedAsync(user).WithCurrentCulture<bool>();
    }

    internal async Task<SecurityToken> CreateSecurityTokenAsync(TKey userId)
    {
      Encoding unicode = Encoding.Unicode;
      return new SecurityToken(unicode.GetBytes(await this.GetSecurityStampAsync(userId).WithCurrentCulture<string>()));
    }

    /// <summary>
    ///     Generate a code that the user can use to change their phone number to a specific number
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public virtual async Task<string> GenerateChangePhoneNumberTokenAsync(
      TKey userId,
      string phoneNumber)
    {
      this.ThrowIfDisposed();
      return Rfc6238AuthenticationService.GenerateCode(await this.CreateSecurityTokenAsync(userId).WithCurrentCulture<SecurityToken>(), phoneNumber).ToString("D6", (IFormatProvider) CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     Verify the code is valid for a specific user and for a specific phone number
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public virtual async Task<bool> VerifyChangePhoneNumberTokenAsync(
      TKey userId,
      string token,
      string phoneNumber)
    {
      this.ThrowIfDisposed();
      SecurityToken securityToken = await this.CreateSecurityTokenAsync(userId).WithCurrentCulture<SecurityToken>();
      int result;
      return securityToken != null && int.TryParse(token, out result) && Rfc6238AuthenticationService.ValidateCode(securityToken, result, phoneNumber);
    }

    /// <summary>Verify a user token with the specified purpose</summary>
    /// <param name="userId"></param>
    /// <param name="purpose"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task<bool> VerifyUserTokenAsync(TKey userId, string purpose, string token)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      if (manager.UserTokenProvider == null)
        throw new NotSupportedException(Resources.NoTokenProvider);
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await manager.UserTokenProvider.ValidateAsync(purpose, token, manager, user).WithCurrentCulture<bool>();
    }

    /// <summary>Get a user token for a specific purpose</summary>
    /// <param name="purpose"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<string> GenerateUserTokenAsync(string purpose, TKey userId)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      if (manager.UserTokenProvider == null)
        throw new NotSupportedException(Resources.NoTokenProvider);
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await manager.UserTokenProvider.GenerateAsync(purpose, manager, user).WithCurrentCulture<string>();
    }

    /// <summary>
    ///     Register a two factor authentication provider with the TwoFactorProviders mapping
    /// </summary>
    /// <param name="twoFactorProvider"></param>
    /// <param name="provider"></param>
    public virtual void RegisterTwoFactorProvider(
      string twoFactorProvider,
      IUserTokenProvider<TUser, TKey> provider)
    {
      this.ThrowIfDisposed();
      if (twoFactorProvider == null)
        throw new ArgumentNullException(nameof (twoFactorProvider));
      this.TwoFactorProviders[twoFactorProvider] = provider != null ? provider : throw new ArgumentNullException(nameof (provider));
    }

    /// <summary>
    ///     Returns a list of valid two factor providers for a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IList<string>> GetValidTwoFactorProvidersAsync(TKey userId)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      List<string> results = new List<string>();
      foreach (KeyValuePair<string, IUserTokenProvider<TUser, TKey>> twoFactorProvider in (IEnumerable<KeyValuePair<string, IUserTokenProvider<TUser, TKey>>>) manager.TwoFactorProviders)
      {
        KeyValuePair<string, IUserTokenProvider<TUser, TKey>> f = twoFactorProvider;
        if (await f.Value.IsValidProviderForUserAsync(manager, user).WithCurrentCulture<bool>())
          results.Add(f.Key);
        f = new KeyValuePair<string, IUserTokenProvider<TUser, TKey>>();
      }
      return (IList<string>) results;
    }

    /// <summary>
    ///     Verify a two factor token with the specified provider
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="twoFactorProvider"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task<bool> VerifyTwoFactorTokenAsync(
      TKey userId,
      string twoFactorProvider,
      string token)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!manager._factors.ContainsKey(twoFactorProvider))
        throw new NotSupportedException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.NoTwoFactorProvider, (object) twoFactorProvider));
      return await manager._factors[twoFactorProvider].ValidateAsync(twoFactorProvider, token, manager, user).WithCurrentCulture<bool>();
    }

    /// <summary>Get a token for a specific two factor provider</summary>
    /// <param name="userId"></param>
    /// <param name="twoFactorProvider"></param>
    /// <returns></returns>
    public virtual async Task<string> GenerateTwoFactorTokenAsync(
      TKey userId,
      string twoFactorProvider)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!manager._factors.ContainsKey(twoFactorProvider))
        throw new NotSupportedException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.NoTwoFactorProvider, (object) twoFactorProvider));
      return await manager._factors[twoFactorProvider].GenerateAsync(twoFactorProvider, manager, user).WithCurrentCulture<string>();
    }

    /// <summary>
    ///     Notify a user with a token using a specific two-factor authentication provider's Notify method
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="twoFactorProvider"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> NotifyTwoFactorTokenAsync(
      TKey userId,
      string twoFactorProvider,
      string token)
    {
      UserManager<TUser, TKey> manager = this;
      manager.ThrowIfDisposed();
      TUser user = await manager.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!manager._factors.ContainsKey(twoFactorProvider))
        throw new NotSupportedException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.NoTwoFactorProvider, (object) twoFactorProvider));
      await manager._factors[twoFactorProvider].NotifyAsync(token, manager, user).WithCurrentCulture();
      return IdentityResult.Success;
    }

    internal IUserTwoFactorStore<TUser, TKey> GetUserTwoFactorStore() => this.Store is IUserTwoFactorStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserTwoFactorStore);

    /// <summary>
    ///     Get whether two factor authentication is enabled for a user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> GetTwoFactorEnabledAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserTwoFactorStore<TUser, TKey> store = this.GetUserTwoFactorStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetTwoFactorEnabledAsync(user).WithCurrentCulture<bool>();
    }

    /// <summary>
    ///     Set whether a user has two factor authentication enabled
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> SetTwoFactorEnabledAsync(TKey userId, bool enabled)
    {
      this.ThrowIfDisposed();
      IUserTwoFactorStore<TUser, TKey> store = this.GetUserTwoFactorStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      TaskExtensions.CultureAwaiter cultureAwaiter = store.SetTwoFactorEnabledAsync(user, enabled).WithCurrentCulture();
      await cultureAwaiter;
      cultureAwaiter = this.UpdateSecurityStampInternal(user).WithCurrentCulture();
      await cultureAwaiter;
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Send an email to the user</summary>
    /// <param name="userId"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public virtual async Task SendEmailAsync(TKey userId, string subject, string body)
    {
      this.ThrowIfDisposed();
      if (this.EmailService == null)
        return;
      IdentityMessage identityMessage1 = new IdentityMessage();
      IdentityMessage identityMessage2 = identityMessage1;
      identityMessage2.Destination = await this.GetEmailAsync(userId).WithCurrentCulture<string>();
      identityMessage1.Subject = subject;
      identityMessage1.Body = body;
      IdentityMessage message = identityMessage1;
      identityMessage2 = (IdentityMessage) null;
      identityMessage1 = (IdentityMessage) null;
      await this.EmailService.SendAsync(message).WithCurrentCulture();
    }

    /// <summary>Send a user a sms message</summary>
    /// <param name="userId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public virtual async Task SendSmsAsync(TKey userId, string message)
    {
      this.ThrowIfDisposed();
      if (this.SmsService == null)
        return;
      IdentityMessage identityMessage1 = new IdentityMessage();
      IdentityMessage identityMessage2 = identityMessage1;
      identityMessage2.Destination = await this.GetPhoneNumberAsync(userId).WithCurrentCulture<string>();
      identityMessage1.Body = message;
      IdentityMessage message1 = identityMessage1;
      identityMessage2 = (IdentityMessage) null;
      identityMessage1 = (IdentityMessage) null;
      await this.SmsService.SendAsync(message1).WithCurrentCulture();
    }

    internal IUserLockoutStore<TUser, TKey> GetUserLockoutStore() => this.Store is IUserLockoutStore<TUser, TKey> store ? store : throw new NotSupportedException(Resources.StoreNotIUserLockoutStore);

    /// <summary>Returns true if the user is locked out</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsLockedOutAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetLockoutEnabledAsync(user).WithCurrentCulture<bool>() && await store.GetLockoutEndDateAsync(user).WithCurrentCulture<DateTimeOffset>() >= DateTimeOffset.UtcNow;
    }

    /// <summary>Sets whether lockout is enabled for this user</summary>
    /// <param name="userId"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> SetLockoutEnabledAsync(TKey userId, bool enabled)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      await store.SetLockoutEnabledAsync(user, enabled).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Returns whether lockout is enabled for the user</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<bool> GetLockoutEnabledAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetLockoutEnabledAsync(user).WithCurrentCulture<bool>();
    }

    /// <summary>
    ///     Returns when the user is no longer locked out, dates in the past are considered as not being locked out
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<DateTimeOffset> GetLockoutEndDateAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetLockoutEndDateAsync(user).WithCurrentCulture<DateTimeOffset>();
    }

    /// <summary>Sets the when a user lockout ends</summary>
    /// <param name="userId"></param>
    /// <param name="lockoutEnd"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> SetLockoutEndDateAsync(
      TKey userId,
      DateTimeOffset lockoutEnd)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (!await store.GetLockoutEnabledAsync(user).WithCurrentCulture<bool>())
        return IdentityResult.Failed(Resources.LockoutNotEnabled);
      await store.SetLockoutEndDateAsync(user, lockoutEnd).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>
    /// Increments the access failed count for the user and if the failed access account is greater than or equal
    /// to the MaxFailedAccessAttempsBeforeLockout, the user will be locked out for the next DefaultAccountLockoutTimeSpan
    /// and the AccessFailedCount will be reset to 0. This is used for locking out the user account.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> AccessFailedAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (await store.IncrementAccessFailedCountAsync(user).WithCurrentCulture<int>() >= this.MaxFailedAccessAttemptsBeforeLockout)
      {
        TaskExtensions.CultureAwaiter cultureAwaiter = store.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.Add(this.DefaultAccountLockoutTimeSpan)).WithCurrentCulture();
        await cultureAwaiter;
        cultureAwaiter = store.ResetAccessFailedCountAsync(user).WithCurrentCulture();
        await cultureAwaiter;
      }
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>Resets the access failed count for the user to 0</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> ResetAccessFailedCountAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      if (await this.GetAccessFailedCountAsync(user.Id).WithCurrentCulture<int>() == 0)
        return IdentityResult.Success;
      await store.ResetAccessFailedCountAsync(user).WithCurrentCulture();
      return await this.UpdateAsync(user).WithCurrentCulture<IdentityResult>();
    }

    /// <summary>
    ///     Returns the number of failed access attempts for the user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<int> GetAccessFailedCountAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      IUserLockoutStore<TUser, TKey> store = this.GetUserLockoutStore();
      TUser user = await this.FindByIdAsync(userId).WithCurrentCulture<TUser>();
      if ((object) user == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, (object) userId));
      return await store.GetAccessFailedCountAsync(user).WithCurrentCulture<int>();
    }

    private void ThrowIfDisposed()
    {
      if (this._disposed)
        throw new ObjectDisposedException(this.GetType().Name);
    }

    /// <summary>When disposing, actually dipose the store</summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this._disposed)
        return;
      this.Store.Dispose();
      this._disposed = true;
    }
  }
}
