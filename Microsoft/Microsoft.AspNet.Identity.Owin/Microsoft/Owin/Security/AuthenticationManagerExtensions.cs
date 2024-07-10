// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.AuthenticationManagerExtensions
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using TaskExtensions = Microsoft.AspNet.Identity.TaskExtensions;

namespace Microsoft.Owin.Security
{
  /// <summary>
  ///     Extensions methods on IAuthenticationManager that add methods for using the default Application and External
  ///     authentication type constants
  /// </summary>
  public static class AuthenticationManagerExtensions
  {
    /// <summary>
    ///     Return the authentication types which are considered external because they have captions
    /// </summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    public static IEnumerable<AuthenticationDescription> GetExternalAuthenticationTypes(
      this IAuthenticationManager manager)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return manager.GetAuthenticationTypes((Func<AuthenticationDescription, bool>) (d => d.Properties != null && d.Properties.ContainsKey("Caption")));
    }

    /// <summary>
    ///     Return the identity associated with the default external authentication type
    /// </summary>
    /// <returns></returns>
    public static async Task<ClaimsIdentity> GetExternalIdentityAsync(
      this IAuthenticationManager manager,
      string externalAuthenticationType)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AuthenticateResult authenticateResult = await TaskExtensions.WithCurrentCulture<AuthenticateResult>(manager.AuthenticateAsync(externalAuthenticationType));
      return authenticateResult == null || authenticateResult.Identity == null || authenticateResult.Identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") == null ? (ClaimsIdentity) null : authenticateResult.Identity;
    }

    /// <summary>
    /// Return the identity associated with the default external authentication type
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="externalAuthenticationType"></param>
    /// <returns></returns>
    public static ClaimsIdentity GetExternalIdentity(
      this IAuthenticationManager manager,
      string externalAuthenticationType)
    {
      return manager != null ? Microsoft.AspNet.Identity.AsyncHelper.RunSync<ClaimsIdentity>((Func<Task<ClaimsIdentity>>) (() => manager.GetExternalIdentityAsync(externalAuthenticationType))) : throw new ArgumentNullException(nameof (manager));
    }

    private static ExternalLoginInfo GetExternalLoginInfo(AuthenticateResult result)
    {
      if (result == null || result.Identity == null)
        return (ExternalLoginInfo) null;
      Claim first = result.Identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
      if (first == null)
        return (ExternalLoginInfo) null;
      string str = result.Identity.Name;
      if (str != null)
        str = str.Replace(" ", "");
      string firstValue = IdentityExtensions.FindFirstValue(result.Identity, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
      return new ExternalLoginInfo()
      {
        ExternalIdentity = result.Identity,
        Login = new UserLoginInfo(first.Issuer, first.Value),
        DefaultUserName = str,
        Email = firstValue
      };
    }

    /// <summary>Extracts login info out of an external identity</summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    public static async Task<ExternalLoginInfo> GetExternalLoginInfoAsync(
      this IAuthenticationManager manager)
    {
      return manager != null ? AuthenticationManagerExtensions.GetExternalLoginInfo(await TaskExtensions.WithCurrentCulture<AuthenticateResult>(manager.AuthenticateAsync("ExternalCookie"))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Extracts login info out of an external identity</summary>
    /// <param name="manager"></param>
    /// <returns></returns>
    public static ExternalLoginInfo GetExternalLoginInfo(this IAuthenticationManager manager) => manager != null
            ? AsyncHelper.RunSync<ExternalLoginInfo>(new Func<Task<ExternalLoginInfo>>((manager).GetExternalLoginInfoAsync))
            : throw new ArgumentNullException(nameof(manager));


    //public static ExternalLoginInfo GetExternalLoginInfo1(this IAuthenticationManager manager)
    //{
    //    if (manager == null)
    //    {
    //        throw new ArgumentNullException("manager");
    //    }

    //    return AsyncHelper.RunSync((Func<Task<ExternalLoginInfo>>)manager.GetExternalLoginInfoAsync);
    //}


        /// <summary>Extracts login info out of an external identity</summary>
        /// <param name="manager"></param>
        /// <param name="xsrfKey">key that will be used to find the userId to verify</param>
        /// <param name="expectedValue">
        ///     the value expected to be found using the xsrfKey in the AuthenticationResult.Properties
        ///     dictionary
        /// </param>
        /// <returns></returns>
        public static ExternalLoginInfo GetExternalLoginInfo(
      this IAuthenticationManager manager,
      string xsrfKey,
      string expectedValue)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      return AsyncHelper.RunSync<ExternalLoginInfo>((Func<Task<ExternalLoginInfo>>) (() => manager.GetExternalLoginInfoAsync(xsrfKey, expectedValue)));
    }

    /// <summary>Extracts login info out of an external identity</summary>
    /// <param name="manager"></param>
    /// <param name="xsrfKey">key that will be used to find the userId to verify</param>
    /// <param name="expectedValue">
    ///     the value expected to be found using the xsrfKey in the AuthenticationResult.Properties
    ///     dictionary
    /// </param>
    /// <returns></returns>
    public static async Task<ExternalLoginInfo> GetExternalLoginInfoAsync(
      this IAuthenticationManager manager,
      string xsrfKey,
      string expectedValue)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AuthenticateResult result = await TaskExtensions.WithCurrentCulture<AuthenticateResult>(manager.AuthenticateAsync("ExternalCookie"));
      return result == null || result.Properties == null || result.Properties.Dictionary == null || !result.Properties.Dictionary.ContainsKey(xsrfKey) || !(result.Properties.Dictionary[xsrfKey] == expectedValue) ? (ExternalLoginInfo) null : AuthenticationManagerExtensions.GetExternalLoginInfo(result);
    }

    /// <summary>
    ///     Returns true if there is a TwoFactorRememberBrowser cookie for a user
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static async Task<bool> TwoFactorBrowserRememberedAsync(
      this IAuthenticationManager manager,
      string userId)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      AuthenticateResult authenticateResult = await TaskExtensions.WithCurrentCulture<AuthenticateResult>(manager.AuthenticateAsync("TwoFactorRememberBrowser"));
      return authenticateResult != null && authenticateResult.Identity != null && IdentityExtensions.GetUserId((IIdentity) authenticateResult.Identity) == userId;
    }

    /// <summary>
    ///     Returns true if there is a TwoFactorRememberBrowser cookie for a user
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool TwoFactorBrowserRemembered(
      this IAuthenticationManager manager,
      string userId)
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.TwoFactorBrowserRememberedAsync(userId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>
    ///     Creates a TwoFactorRememberBrowser cookie for a user
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static ClaimsIdentity CreateTwoFactorRememberBrowserIdentity(
      this IAuthenticationManager manager,
      string userId)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      ClaimsIdentity rememberBrowserIdentity = new ClaimsIdentity("TwoFactorRememberBrowser");
      rememberBrowserIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));
      return rememberBrowserIdentity;
    }
  }
}
