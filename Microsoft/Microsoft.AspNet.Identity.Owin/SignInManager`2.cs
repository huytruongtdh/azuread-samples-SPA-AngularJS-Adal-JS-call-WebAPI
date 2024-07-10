// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.SignInManager`2
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>Manages Sign In operations for users</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class SignInManager<TUser, TKey> : IDisposable
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    private string _authType;

    public SignInManager(
      Microsoft.AspNet.Identity.UserManager<TUser, TKey> userManager,
      IAuthenticationManager authenticationManager)
    {
      if (userManager == null)
        throw new ArgumentNullException(nameof (userManager));
      if (authenticationManager == null)
        throw new ArgumentNullException(nameof (authenticationManager));
      this.UserManager = userManager;
      this.AuthenticationManager = authenticationManager;
    }

    /// <summary>
    /// AuthenticationType that will be used by sign in, defaults to DefaultAuthenticationTypes.ApplicationCookie
    /// </summary>
    public string AuthenticationType
    {
      get => this._authType ?? "ApplicationCookie";
      set => this._authType = value;
    }

    /// <summary>Used to operate on users</summary>
    public Microsoft.AspNet.Identity.UserManager<TUser, TKey> UserManager { get; set; }

    /// <summary>Used to sign in identities</summary>
    public IAuthenticationManager AuthenticationManager { get; set; }

    /// <summary>
    /// Called to generate the ClaimsIdentity for the user, override to add additional claims before SignIn
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual Task<ClaimsIdentity> CreateUserIdentityAsync(TUser user) => this.UserManager.CreateIdentityAsync(user, this.AuthenticationType);

    /// <summary>
    /// Convert a TKey userId to a string, by default this just calls ToString()
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual string ConvertIdToString(TKey id) => Convert.ToString((object) id, (IFormatProvider) CultureInfo.InvariantCulture);

    /// <summary>
    /// Convert a string id to the proper TKey using Convert.ChangeType
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual TKey ConvertIdFromString(string id) => id == null ? default (TKey) : (TKey) Convert.ChangeType((object) id, typeof (TKey), (IFormatProvider) CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a user identity and then signs the identity using the AuthenticationManager
    /// </summary>
    /// <param name="user"></param>
    /// <param name="isPersistent"></param>
    /// <param name="rememberBrowser"></param>
    /// <returns></returns>
    public virtual async Task SignInAsync(TUser user, bool isPersistent, bool rememberBrowser)
    {
      ClaimsIdentity claimsIdentity = await TaskExtensions.WithCurrentCulture<ClaimsIdentity>(this.CreateUserIdentityAsync(user));
      this.AuthenticationManager.SignOut("ExternalCookie", "TwoFactorCookie");
      if (rememberBrowser)
      {
        ClaimsIdentity rememberBrowserIdentity = this.AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(this.ConvertIdToString(((IUser<TKey>) (object) user).Id));
        IAuthenticationManager authenticationManager = this.AuthenticationManager;
        AuthenticationProperties properties = new AuthenticationProperties();
        properties.IsPersistent = isPersistent;
        ClaimsIdentity[] claimsIdentityArray = new ClaimsIdentity[2]
        {
          claimsIdentity,
          rememberBrowserIdentity
        };
        authenticationManager.SignIn(properties, claimsIdentityArray);
      }
      else
      {
        IAuthenticationManager authenticationManager = this.AuthenticationManager;
        AuthenticationProperties properties = new AuthenticationProperties();
        properties.IsPersistent = isPersistent;
        ClaimsIdentity[] claimsIdentityArray = new ClaimsIdentity[1]
        {
          claimsIdentity
        };
        authenticationManager.SignIn(properties, claimsIdentityArray);
      }
    }

    /// <summary>Send a two factor code to a user</summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public virtual async Task<bool> SendTwoFactorCodeAsync(string provider)
    {
      TKey userId = await TaskExtensions.WithCurrentCulture<TKey>(this.GetVerifiedUserIdAsync());
      if ((object) userId == null)
        return false;
      string str = await TaskExtensions.WithCurrentCulture<string>(this.UserManager.GenerateTwoFactorTokenAsync(userId, provider));
      IdentityResult identityResult = await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UserManager.NotifyTwoFactorTokenAsync(userId, provider, str));
      return true;
    }

    /// <summary>Get the user id that has been verified already or null.</summary>
    /// <returns></returns>
    public async Task<TKey> GetVerifiedUserIdAsync()
    {
      AuthenticateResult authenticateResult = await TaskExtensions.WithCurrentCulture<AuthenticateResult>(this.AuthenticationManager.AuthenticateAsync("TwoFactorCookie"));
      return authenticateResult == null || authenticateResult.Identity == null || string.IsNullOrEmpty(IdentityExtensions.GetUserId((IIdentity) authenticateResult.Identity)) ? default (TKey) : this.ConvertIdFromString(IdentityExtensions.GetUserId((IIdentity) authenticateResult.Identity));
    }

    /// <summary>
    /// Has the user been verified (ie either via password or external login)
    /// </summary>
    /// <returns></returns>
    public async Task<bool> HasBeenVerifiedAsync() => (object) await TaskExtensions.WithCurrentCulture<TKey>(this.GetVerifiedUserIdAsync()) != null;

    /// <summary>Two factor verification step</summary>
    /// <param name="provider"></param>
    /// <param name="code"></param>
    /// <param name="isPersistent"></param>
    /// <param name="rememberBrowser"></param>
    /// <returns></returns>
    public virtual async Task<SignInStatus> TwoFactorSignInAsync(
      string provider,
      string code,
      bool isPersistent,
      bool rememberBrowser)
    {
      TKey key = await TaskExtensions.WithCurrentCulture<TKey>(this.GetVerifiedUserIdAsync());
      if ((object) key == null)
        return SignInStatus.Failure;
      TUser user = await TaskExtensions.WithCurrentCulture<TUser>(this.UserManager.FindByIdAsync(key));
      if ((object) user == null)
        return SignInStatus.Failure;
      if (await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.IsLockedOutAsync(((IUser<TKey>) (object) user).Id)))
        return SignInStatus.LockedOut;
      if (await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.VerifyTwoFactorTokenAsync(((IUser<TKey>) (object) user).Id, provider, code)))
      {
        if (!(await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UserManager.ResetAccessFailedCountAsync(((IUser<TKey>) (object) user).Id))).Succeeded)
          return SignInStatus.Failure;
        await TaskExtensions.WithCurrentCulture(this.SignInAsync(user, isPersistent, rememberBrowser));
        return SignInStatus.Success;
      }
      int num = (await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UserManager.AccessFailedAsync(((IUser<TKey>) (object) user).Id))).Succeeded ? 1 : 0;
      return SignInStatus.Failure;
    }

    /// <summary>Sign the user in using an associated external login</summary>
    /// <param name="loginInfo"></param>
    /// <param name="isPersistent"></param>
    /// <returns></returns>
    public async Task<SignInStatus> ExternalSignInAsync(
      ExternalLoginInfo loginInfo,
      bool isPersistent)
    {
      TUser user = await TaskExtensions.WithCurrentCulture<TUser>(this.UserManager.FindAsync(loginInfo.Login));
      if ((object) user == null)
        return SignInStatus.Failure;
      return await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.IsLockedOutAsync(((IUser<TKey>) (object) user).Id)) ? SignInStatus.LockedOut : await TaskExtensions.WithCurrentCulture<SignInStatus>(this.SignInOrTwoFactor(user, isPersistent));
    }

    private async Task<bool> IsTwoFactorEnabled(TUser user)
    {
      bool flag = await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.GetTwoFactorEnabledAsync(((IUser<TKey>) (object) user).Id));
      if (flag)
        flag = (await TaskExtensions.WithCurrentCulture<IList<string>>(this.UserManager.GetValidTwoFactorProvidersAsync(((IUser<TKey>) (object) user).Id))).Count > 0;
      return flag;
    }

    private async Task<SignInStatus> SignInOrTwoFactor(TUser user, bool isPersistent)
    {
      string id = Convert.ToString((object) ((IUser<TKey>) (object) user).Id);
      bool flag = await this.IsTwoFactorEnabled(user);
      if (flag)
        flag = !await TaskExtensions.WithCurrentCulture<bool>(this.AuthenticationManager.TwoFactorBrowserRememberedAsync(id));
      if (flag)
      {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity("TwoFactorCookie");
        claimsIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", id));
        this.AuthenticationManager.SignIn(claimsIdentity);
        return SignInStatus.RequiresVerification;
      }
      await TaskExtensions.WithCurrentCulture(this.SignInAsync(user, isPersistent, false));
      return SignInStatus.Success;
    }

    /// <summary>Sign in the user in using the user name and password</summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="isPersistent"></param>
    /// <param name="shouldLockout"></param>
    /// <returns></returns>
    public virtual async Task<SignInStatus> PasswordSignInAsync(
      string userName,
      string password,
      bool isPersistent,
      bool shouldLockout)
    {
      if (this.UserManager == null)
        return SignInStatus.Failure;
      TUser user = await TaskExtensions.WithCurrentCulture<TUser>(this.UserManager.FindByNameAsync(userName));
      if ((object) user == null)
        return SignInStatus.Failure;
      if (await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.IsLockedOutAsync(((IUser<TKey>) (object) user).Id)))
        return SignInStatus.LockedOut;
      if (await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.CheckPasswordAsync(user, password)))
      {
        if (!await this.IsTwoFactorEnabled(user))
        {
          if (!(await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UserManager.ResetAccessFailedCountAsync(((IUser<TKey>) (object) user).Id))).Succeeded)
            return SignInStatus.Failure;
        }
        return await TaskExtensions.WithCurrentCulture<SignInStatus>(this.SignInOrTwoFactor(user, isPersistent));
      }
      if (shouldLockout)
      {
        if (!(await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UserManager.AccessFailedAsync(((IUser<TKey>) (object) user).Id))).Succeeded)
          return SignInStatus.Failure;
        if (await TaskExtensions.WithCurrentCulture<bool>(this.UserManager.IsLockedOutAsync(((IUser<TKey>) (object) user).Id)))
          return SignInStatus.LockedOut;
      }
      return SignInStatus.Failure;
    }

    /// <summary>Dispose</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>
    ///     If disposing, calls dispose on the Context.  Always nulls out the Context
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
    }
  }
}
