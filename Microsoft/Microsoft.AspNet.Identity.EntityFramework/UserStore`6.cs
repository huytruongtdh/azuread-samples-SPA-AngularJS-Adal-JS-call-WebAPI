// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.UserStore`6
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  ///     EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and
  ///     IUserRoleStore
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TUserLogin"></typeparam>
  /// <typeparam name="TUserRole"></typeparam>
  /// <typeparam name="TUserClaim"></typeparam>
  public class UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> : 
    IUserLoginStore<TUser, TKey>,
    IUserStore<TUser, TKey>,
    IDisposable,
    IUserClaimStore<TUser, TKey>,
    IUserRoleStore<TUser, TKey>,
    IUserPasswordStore<TUser, TKey>,
    IUserSecurityStampStore<TUser, TKey>,
    IQueryableUserStore<TUser, TKey>,
    IUserEmailStore<TUser, TKey>,
    IUserPhoneNumberStore<TUser, TKey>,
    IUserTwoFactorStore<TUser, TKey>,
    IUserLockoutStore<TUser, TKey>
    where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>
    where TRole : IdentityRole<TKey, TUserRole>
    where TKey : IEquatable<TKey>
    where TUserLogin : IdentityUserLogin<TKey>, new()
    where TUserRole : IdentityUserRole<TKey>, new()
    where TUserClaim : IdentityUserClaim<TKey>, new()
  {
    private readonly IDbSet<TUserLogin> _logins;
    private readonly EntityStore<TRole> _roleStore;
    private readonly IDbSet<TUserClaim> _userClaims;
    private readonly IDbSet<TUserRole> _userRoles;
    private bool _disposed;
    private EntityStore<TUser> _userStore;

    /// <summary>
    ///     Constructor which takes a db context and wires up the stores with default instances using the context
    /// </summary>
    /// <param name="context"></param>
    public UserStore(DbContext context)
    {
      this.Context = context != null ? context : throw new ArgumentNullException(nameof (context));
      this.AutoSaveChanges = true;
      this._userStore = new EntityStore<TUser>(context);
      this._roleStore = new EntityStore<TRole>(context);
      this._logins = (IDbSet<TUserLogin>) this.Context.Set<TUserLogin>();
      this._userClaims = (IDbSet<TUserClaim>) this.Context.Set<TUserClaim>();
      this._userRoles = (IDbSet<TUserRole>) this.Context.Set<TUserRole>();
    }

    /// <summary>Context for the store</summary>
    public DbContext Context { get; private set; }

    /// <summary>
    ///     If true will call dispose on the DbContext during Dispose
    /// </summary>
    public bool DisposeContext { get; set; }

    /// <summary>
    ///     If true will call SaveChanges after Create/Update/Delete
    /// </summary>
    public bool AutoSaveChanges { get; set; }

    /// <summary>Returns an IQueryable of users</summary>
    public IQueryable<TUser> Users => this._userStore.EntitySet;

    /// <summary>Return the claims for a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IList<Claim>> GetClaimsAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      await this.EnsureClaimsLoaded(user).WithCurrentCulture();
      return (IList<Claim>) user.Claims.Select<TUserClaim, Claim>((Func<TUserClaim, Claim>) (c => new Claim(c.ClaimType, c.ClaimValue))).ToList<Claim>();
    }

    /// <summary>Add a claim to a user</summary>
    /// <param name="user"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public virtual Task AddClaimAsync(TUser user, Claim claim)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (claim == null)
        throw new ArgumentNullException(nameof (claim));
      IDbSet<TUserClaim> userClaims = this._userClaims;
      TUserClaim entity = new TUserClaim();
      entity.UserId = user.Id;
      entity.ClaimType = claim.Type;
      entity.ClaimValue = claim.Value;
      userClaims.Add(entity);
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Remove a claim from a user</summary>
    /// <param name="user"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    public virtual async Task RemoveClaimAsync(TUser user, Claim claim)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      string claimValue = claim != null ? claim.Value : throw new ArgumentNullException(nameof (claim));
      string claimType = claim.Type;
      IEnumerable<TUserClaim> userClaims;
      if (this.AreClaimsLoaded(user))
      {
        userClaims = (IEnumerable<TUserClaim>) user.Claims.Where<TUserClaim>((Func<TUserClaim, bool>) (uc => uc.ClaimValue == claimValue && uc.ClaimType == claimType)).ToList<TUserClaim>();
      }
      else
      {
        TKey userId = user.Id;
        userClaims = (IEnumerable<TUserClaim>) await this._userClaims.Where<TUserClaim>((Expression<Func<TUserClaim, bool>>) (uc => uc.ClaimValue == claimValue && uc.ClaimType == claimType && uc.UserId.Equals(userId))).ToListAsync<TUserClaim>().WithCurrentCulture<List<TUserClaim>>();
      }
      foreach (TUserClaim entity in userClaims)
        this._userClaims.Remove(entity);
    }

    /// <summary>Returns whether the user email is confirmed</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> GetEmailConfirmedAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<bool>(user.EmailConfirmed) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Set IsConfirmed on the user</summary>
    /// <param name="user"></param>
    /// <param name="confirmed"></param>
    /// <returns></returns>
    public virtual Task SetEmailConfirmedAsync(TUser user, bool confirmed)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.EmailConfirmed = confirmed;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Set the user email</summary>
    /// <param name="user"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public virtual Task SetEmailAsync(TUser user, string email)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.Email = email;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Get the user's email</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<string> GetEmailAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<string>(user.Email) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Find a user by email</summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByEmailAsync(string email)
    {
      this.ThrowIfDisposed();
      return this.GetUserAggregateAsync((Expression<Func<TUser, bool>>) (u => u.Email.ToUpper() == email.ToUpper()));
    }

    /// <summary>
    ///     Returns the DateTimeOffset that represents the end of a user's lockout, any time in the past should be considered
    ///     not locked out.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
    {
      this.ThrowIfDisposed();
      DateTime? nullable = (object) user != null ? user.LockoutEndDateUtc : throw new ArgumentNullException(nameof (user));
      DateTimeOffset result;
      if (!nullable.HasValue)
      {
        result = new DateTimeOffset();
      }
      else
      {
        nullable = user.LockoutEndDateUtc;
        result = new DateTimeOffset(DateTime.SpecifyKind(nullable.Value, DateTimeKind.Utc));
      }
      return Task.FromResult<DateTimeOffset>(result);
    }

    /// <summary>
    ///     Locks a user out until the specified end date (set to a past date, to unlock a user)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="lockoutEnd"></param>
    /// <returns></returns>
    public virtual Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.LockoutEndDateUtc = lockoutEnd == DateTimeOffset.MinValue ? new DateTime?() : new DateTime?(lockoutEnd.UtcDateTime);
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>
    ///     Used to record when an attempt to access the user has failed
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<int> IncrementAccessFailedCountAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      ++user.AccessFailedCount;
      return Task.FromResult<int>(user.AccessFailedCount);
    }

    /// <summary>
    ///     Used to reset the account access count, typically after the account is successfully accessed
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task ResetAccessFailedCountAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.AccessFailedCount = 0;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>
    ///     Returns the current number of failed access attempts.  This number usually will be reset whenever the password is
    ///     verified or the account is locked out.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<int> GetAccessFailedCountAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<int>(user.AccessFailedCount) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Returns whether the user can be locked out.</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> GetLockoutEnabledAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<bool>(user.LockoutEnabled) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Sets whether the user can be locked out.</summary>
    /// <param name="user"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public virtual Task SetLockoutEnabledAsync(TUser user, bool enabled)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.LockoutEnabled = enabled;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Find a user by id</summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByIdAsync(TKey userId)
    {
      this.ThrowIfDisposed();
      return this.GetUserAggregateAsync((Expression<Func<TUser, bool>>) (u => u.Id.Equals(userId)));
    }

    /// <summary>Find a user by name</summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public virtual Task<TUser> FindByNameAsync(string userName)
    {
      this.ThrowIfDisposed();
      return this.GetUserAggregateAsync((Expression<Func<TUser, bool>>) (u => u.UserName.ToUpper() == userName.ToUpper()));
    }

    /// <summary>Insert an entity</summary>
    /// <param name="user"></param>
    public virtual async Task CreateAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      this._userStore.Create(user);
      await this.SaveChanges().WithCurrentCulture();
    }

    /// <summary>Mark an entity for deletion</summary>
    /// <param name="user"></param>
    public virtual async Task DeleteAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      this._userStore.Delete(user);
      await this.SaveChanges().WithCurrentCulture();
    }

    /// <summary>Update an entity</summary>
    /// <param name="user"></param>
    public virtual async Task UpdateAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      this._userStore.Update(user);
      await this.SaveChanges().WithCurrentCulture();
    }

    /// <summary>Dispose the store</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>Returns the user associated with this login</summary>
    /// <returns></returns>
    public virtual async Task<TUser> FindAsync(UserLoginInfo login)
    {
      UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> userStore = this;
      userStore.ThrowIfDisposed();
      string provider = login != null ? login.LoginProvider : throw new ArgumentNullException(nameof (login));
      string key = login.ProviderKey;
      TUserLogin userLogin = await userStore._logins.FirstOrDefaultAsync<TUserLogin>((Expression<Func<TUserLogin, bool>>) (l => l.LoginProvider == provider && l.ProviderKey == key)).WithCurrentCulture<TUserLogin>();
      if ((object) userLogin == null)
        return default (TUser);
      TKey userId = userLogin.UserId;
      return await userStore.GetUserAggregateAsync((Expression<Func<TUser, bool>>) (u => u.Id.Equals(userId))).WithCurrentCulture<TUser>();
    }

    /// <summary>Add a login to the user</summary>
    /// <param name="user"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public virtual Task AddLoginAsync(TUser user, UserLoginInfo login)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (login == null)
        throw new ArgumentNullException(nameof (login));
      IDbSet<TUserLogin> logins = this._logins;
      TUserLogin entity = new TUserLogin();
      entity.UserId = user.Id;
      entity.ProviderKey = login.ProviderKey;
      entity.LoginProvider = login.LoginProvider;
      logins.Add(entity);
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Remove a login from a user</summary>
    /// <param name="user"></param>
    /// <param name="login"></param>
    /// <returns></returns>
    public virtual async Task RemoveLoginAsync(TUser user, UserLoginInfo login)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      string provider = login != null ? login.LoginProvider : throw new ArgumentNullException(nameof (login));
      string key = login.ProviderKey;
      TUserLogin entity;
      if (this.AreLoginsLoaded(user))
      {
        entity = user.Logins.SingleOrDefault<TUserLogin>((Func<TUserLogin, bool>) (ul => ul.LoginProvider == provider && ul.ProviderKey == key));
      }
      else
      {
        TKey userId = user.Id;
        entity = await this._logins.SingleOrDefaultAsync<TUserLogin>((Expression<Func<TUserLogin, bool>>) (ul => ul.LoginProvider == provider && ul.ProviderKey == key && ul.UserId.Equals(userId))).WithCurrentCulture<TUserLogin>();
      }
      if ((object) entity == null)
        return;
      this._logins.Remove(entity);
    }

    /// <summary>Get the logins for a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      await this.EnsureLoginsLoaded(user).WithCurrentCulture();
      return (IList<UserLoginInfo>) user.Logins.Select<TUserLogin, UserLoginInfo>((Func<TUserLogin, UserLoginInfo>) (l => new UserLoginInfo(l.LoginProvider, l.ProviderKey))).ToList<UserLoginInfo>();
    }

    /// <summary>Set the password hash for a user</summary>
    /// <param name="user"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    public virtual Task SetPasswordHashAsync(TUser user, string passwordHash)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.PasswordHash = passwordHash;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Get the password hash for a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<string> GetPasswordHashAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<string>(user.PasswordHash) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Returns true if the user has a password set</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> HasPasswordAsync(TUser user) => Task.FromResult<bool>(user.PasswordHash != null);

    /// <summary>Set the user's phone number</summary>
    /// <param name="user"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public virtual Task SetPhoneNumberAsync(TUser user, string phoneNumber)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.PhoneNumber = phoneNumber;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Get a user's phone number</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<string> GetPhoneNumberAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<string>(user.PhoneNumber) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Returns whether the user phoneNumber is confirmed</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<bool>(user.PhoneNumberConfirmed) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>Set PhoneNumberConfirmed on the user</summary>
    /// <param name="user"></param>
    /// <param name="confirmed"></param>
    /// <returns></returns>
    public virtual Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.PhoneNumberConfirmed = confirmed;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Add a user to a role</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public virtual async Task AddToRoleAsync(TUser user, string roleName)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (string.IsNullOrWhiteSpace(roleName))
        throw new ArgumentException(IdentityResources.ValueCannotBeNullOrEmpty, nameof (roleName));
      TRole role = await this._roleStore.DbEntitySet.SingleOrDefaultAsync<TRole>((Expression<Func<TRole, bool>>) (r => r.Name.ToUpper() == roleName.ToUpper())).WithCurrentCulture<TRole>();
      if ((object) role == null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, IdentityResources.RoleNotFound, (object) roleName));
      TUserRole entity = new TUserRole();
      entity.UserId = user.Id;
      entity.RoleId = role.Id;
      this._userRoles.Add(entity);
    }

    /// <summary>Remove a user from a role</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public virtual async Task RemoveFromRoleAsync(TUser user, string roleName)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (string.IsNullOrWhiteSpace(roleName))
        throw new ArgumentException(IdentityResources.ValueCannotBeNullOrEmpty, nameof (roleName));
      TRole role = await this._roleStore.DbEntitySet.SingleOrDefaultAsync<TRole>((Expression<Func<TRole, bool>>) (r => r.Name.ToUpper() == roleName.ToUpper())).WithCurrentCulture<TRole>();
      if ((object) role == null)
        return;
      TKey roleId = role.Id;
      TKey userId = user.Id;
      TUserRole entity = await this._userRoles.FirstOrDefaultAsync<TUserRole>((Expression<Func<TUserRole, bool>>) (r => roleId.Equals(r.RoleId) && r.UserId.Equals(userId))).WithCurrentCulture<TUserRole>();
      if ((object) entity == null)
        return;
      this._userRoles.Remove(entity);
    }

    /// <summary>Get the names of the roles a user is a member of</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual async Task<IList<string>> GetRolesAsync(TUser user)
    {
      this.ThrowIfDisposed();
      TKey userId = (object) user != null ? user.Id : throw new ArgumentNullException(nameof (user));
      return (IList<string>) await this._userRoles.Where<TUserRole>((Expression<Func<TUserRole, bool>>) (userRole => userRole.UserId.Equals(userId))).Join<TUserRole, TRole, TKey, string>((IEnumerable<TRole>) this._roleStore.DbEntitySet, (Expression<Func<TUserRole, TKey>>) (userRole => userRole.RoleId), (Expression<Func<TRole, TKey>>) (role => role.Id), (Expression<Func<TUserRole, TRole, string>>) ((userRole, role) => role.Name)).ToListAsync<string>().WithCurrentCulture<List<string>>();
    }

    /// <summary>Returns true if the user is in the named role</summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public virtual async Task<bool> IsInRoleAsync(TUser user, string roleName)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      if (string.IsNullOrWhiteSpace(roleName))
        throw new ArgumentException(IdentityResources.ValueCannotBeNullOrEmpty, nameof (roleName));
      TRole role = await this._roleStore.DbEntitySet.SingleOrDefaultAsync<TRole>((Expression<Func<TRole, bool>>) (r => r.Name.ToUpper() == roleName.ToUpper())).WithCurrentCulture<TRole>();
      if ((object) role == null)
        return false;
      TKey userId = user.Id;
      TKey roleId = role.Id;
      return await this._userRoles.AnyAsync<TUserRole>((Expression<Func<TUserRole, bool>>) (ur => ur.RoleId.Equals(roleId) && ur.UserId.Equals(userId))).WithCurrentCulture<bool>();
    }

    /// <summary>Set the security stamp for the user</summary>
    /// <param name="user"></param>
    /// <param name="stamp"></param>
    /// <returns></returns>
    public virtual Task SetSecurityStampAsync(TUser user, string stamp)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.SecurityStamp = stamp;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>Get the security stamp for a user</summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<string> GetSecurityStampAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<string>(user.SecurityStamp) : throw new ArgumentNullException(nameof (user));
    }

    /// <summary>
    ///     Set whether two factor authentication is enabled for the user
    /// </summary>
    /// <param name="user"></param>
    /// <param name="enabled"></param>
    /// <returns></returns>
    public virtual Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
    {
      this.ThrowIfDisposed();
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      user.TwoFactorEnabled = enabled;
      return (Task) Task.FromResult<int>(0);
    }

    /// <summary>
    ///     Gets whether two factor authentication is enabled for the user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<bool> GetTwoFactorEnabledAsync(TUser user)
    {
      this.ThrowIfDisposed();
      return (object) user != null ? Task.FromResult<bool>(user.TwoFactorEnabled) : throw new ArgumentNullException(nameof (user));
    }

    private async Task SaveChanges()
    {
      if (!this.AutoSaveChanges)
        return;
      int num = await this.Context.SaveChangesAsync().WithCurrentCulture<int>();
    }

    private bool AreClaimsLoaded(TUser user) => this.Context.Entry<TUser>(user).Collection<TUserClaim>((Expression<Func<TUser, ICollection<TUserClaim>>>) (u => u.Claims)).IsLoaded;

    private async Task EnsureClaimsLoaded(TUser user)
    {
      if (this.AreClaimsLoaded(user))
        return;
      TKey userId = user.Id;
      await this._userClaims.Where<TUserClaim>((Expression<Func<TUserClaim, bool>>) (uc => uc.UserId.Equals(userId))).LoadAsync().WithCurrentCulture();
      this.Context.Entry<TUser>(user).Collection<TUserClaim>((Expression<Func<TUser, ICollection<TUserClaim>>>) (u => u.Claims)).IsLoaded = true;
    }

    private async Task EnsureRolesLoaded(TUser user)
    {
      if (this.Context.Entry<TUser>(user).Collection<TUserRole>((Expression<Func<TUser, ICollection<TUserRole>>>) (u => u.Roles)).IsLoaded)
        return;
      TKey userId = user.Id;
      await this._userRoles.Where<TUserRole>((Expression<Func<TUserRole, bool>>) (uc => uc.UserId.Equals(userId))).LoadAsync().WithCurrentCulture();
      this.Context.Entry<TUser>(user).Collection<TUserRole>((Expression<Func<TUser, ICollection<TUserRole>>>) (u => u.Roles)).IsLoaded = true;
    }

    private bool AreLoginsLoaded(TUser user) => this.Context.Entry<TUser>(user).Collection<TUserLogin>((Expression<Func<TUser, ICollection<TUserLogin>>>) (u => u.Logins)).IsLoaded;

    private async Task EnsureLoginsLoaded(TUser user)
    {
      if (this.AreLoginsLoaded(user))
        return;
      TKey userId = user.Id;
      await this._logins.Where<TUserLogin>((Expression<Func<TUserLogin, bool>>) (uc => uc.UserId.Equals(userId))).LoadAsync().WithCurrentCulture();
      this.Context.Entry<TUser>(user).Collection<TUserLogin>((Expression<Func<TUser, ICollection<TUserLogin>>>) (u => u.Logins)).IsLoaded = true;
    }

    /// <summary>
    /// Used to attach child entities to the User aggregate, i.e. Roles, Logins, and Claims
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    protected virtual async Task<TUser> GetUserAggregateAsync(Expression<Func<TUser, bool>> filter)
    {
      TUser user;
      TKey id;
      if (UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.FindByIdFilterParser.TryMatchAndGetId(filter, out id))
        user = await this._userStore.GetByIdAsync((object) id).WithCurrentCulture<TUser>();
      else
        user = await this.Users.FirstOrDefaultAsync<TUser>(filter).WithCurrentCulture<TUser>();
      if ((object) user != null)
      {
        await this.EnsureClaimsLoaded(user).WithCurrentCulture();
        await this.EnsureLoginsLoaded(user).WithCurrentCulture();
        await this.EnsureRolesLoaded(user).WithCurrentCulture();
      }
      return user;
    }

    private void ThrowIfDisposed()
    {
      if (this._disposed)
        throw new ObjectDisposedException(this.GetType().Name);
    }

    /// <summary>
    ///     If disposing, calls dispose on the Context.  Always nulls out the Context
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (this.DisposeContext & disposing && this.Context != null)
        this.Context.Dispose();
      this._disposed = true;
      this.Context = (DbContext) null;
      this._userStore = (EntityStore<TUser>) null;
    }

    private static class FindByIdFilterParser
    {
      private static readonly Expression<Func<TUser, bool>> Predicate = (Expression<Func<TUser, bool>>) (u => u.Id.Equals(default (TKey)));
      private static readonly MethodInfo EqualsMethodInfo = ((MethodCallExpression) UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.FindByIdFilterParser.Predicate.Body).Method;
      private static readonly MemberInfo UserIdMemberInfo = ((MemberExpression) ((MethodCallExpression) UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.FindByIdFilterParser.Predicate.Body).Object).Member;

      internal static bool TryMatchAndGetId(Expression<Func<TUser, bool>> filter, out TKey id)
      {
        id = default (TKey);
        if (filter.Body.NodeType != ExpressionType.Call)
          return false;
        MethodCallExpression body = (MethodCallExpression) filter.Body;
        if (body.Method != UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.FindByIdFilterParser.EqualsMethodInfo || body.Object == null || body.Object.NodeType != ExpressionType.MemberAccess || ((MemberExpression) body.Object).Member != UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.FindByIdFilterParser.UserIdMemberInfo || body.Arguments.Count != 1)
          return false;
        MemberExpression operand;
        if (body.Arguments[0].NodeType == ExpressionType.Convert)
        {
          UnaryExpression unaryExpression = (UnaryExpression) body.Arguments[0];
          if (unaryExpression.Operand.NodeType != ExpressionType.MemberAccess)
            return false;
          operand = (MemberExpression) unaryExpression.Operand;
        }
        else
        {
          if (body.Arguments[0].NodeType != ExpressionType.MemberAccess)
            return false;
          operand = (MemberExpression) body.Arguments[0];
        }
        if (operand.Member.MemberType != MemberTypes.Field || operand.Expression.NodeType != ExpressionType.Constant)
          return false;
        FieldInfo member = (FieldInfo) operand.Member;
        object obj = ((ConstantExpression) operand.Expression).Value;
        id = (TKey) member.GetValue(obj);
        return true;
      }
    }
  }
}
