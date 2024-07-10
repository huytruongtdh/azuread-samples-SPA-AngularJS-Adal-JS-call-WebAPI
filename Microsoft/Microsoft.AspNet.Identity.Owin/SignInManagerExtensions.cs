// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.SignInManagerExtensions
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>Extension methods for SignInManager/&gt;</summary>
  public static class SignInManagerExtensions
  {
    /// <summary>
    /// Called to generate the ClaimsIdentity for the user, override to add additional claims before SignIn
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static ClaimsIdentity CreateUserIdentity<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      TUser user)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<ClaimsIdentity>((Func<Task<ClaimsIdentity>>) (() => manager.CreateUserIdentityAsync(user))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    /// Creates a user identity and then signs the identity using the AuthenticationManager
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <param name="isPersistent"></param>
    /// <param name="rememberBrowser"></param>
    /// <returns></returns>
    public static void SignIn<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      TUser user,
      bool isPersistent,
      bool rememberBrowser)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AsyncHelper.RunSync((Func<Task>) (() => manager.SignInAsync(user, isPersistent, rememberBrowser)));
    }

    /// <summary>Send a two factor code to a user</summary>
    /// <param name="manager"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static bool SendTwoFactorCode<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      string provider)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.SendTwoFactorCodeAsync(provider))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Get the user id that has been verified already or null.</summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    public static TKey GetVerifiedUserId<TUser, TKey>(this SignInManager<TUser, TKey> manager)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TKey>((Func<Task<TKey>>) (() => manager.GetVerifiedUserIdAsync())) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    /// Has the user been verified (ie either via password or external login)
    /// </summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    public static bool HasBeenVerified<TUser, TKey>(this SignInManager<TUser, TKey> manager)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.HasBeenVerifiedAsync())) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Two factor verification step</summary>
    /// <param name="manager"></param>
    /// <param name="provider"></param>
    /// <param name="code"></param>
    /// <param name="isPersistent"></param>
    /// <param name="rememberBrowser"></param>
    /// <returns></returns>
    public static SignInStatus TwoFactorSignIn<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      string provider,
      string code,
      bool isPersistent,
      bool rememberBrowser)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<SignInStatus>((Func<Task<SignInStatus>>) (() => manager.TwoFactorSignInAsync(provider, code, isPersistent, rememberBrowser)));
    }

    /// <summary>Sign the user in using an associated external login</summary>
    /// <param name="manager"></param>
    /// <param name="loginInfo"></param>
    /// <param name="isPersistent"></param>
    /// <returns></returns>
    public static SignInStatus ExternalSignIn<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      ExternalLoginInfo loginInfo,
      bool isPersistent)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<SignInStatus>((Func<Task<SignInStatus>>) (() => manager.ExternalSignInAsync(loginInfo, isPersistent)));
    }

    /// <summary>Sign in the user in using the user name and password</summary>
    /// <param name="manager"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="isPersistent"></param>
    /// <param name="shouldLockout"></param>
    /// <returns></returns>
    public static SignInStatus PasswordSignIn<TUser, TKey>(
      this SignInManager<TUser, TKey> manager,
      string userName,
      string password,
      bool isPersistent,
      bool shouldLockout)
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<SignInStatus>((Func<Task<SignInStatus>>) (() => manager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout)));
    }
  }
}
