// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.SecurityStampValidator
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin.Security.Cookies;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Static helper class used to configure a CookieAuthenticationProvider to validate a cookie against a user's security
  ///     stamp
  /// </summary>
  public static class SecurityStampValidator
  {
    /// <summary>
    ///     Can be used as the ValidateIdentity method for a CookieAuthenticationProvider which will check a user's security
    ///     stamp after validateInterval
    ///     Rejects the identity if the stamp changes, and otherwise will call regenerateIdentity to sign in a new
    ///     ClaimsIdentity
    /// </summary>
    /// <typeparam name="TManager"></typeparam>
    /// <typeparam name="TUser"></typeparam>
    /// <param name="validateInterval"></param>
    /// <param name="regenerateIdentity"></param>
    /// <returns></returns>
    public static Func<CookieValidateIdentityContext, Task> OnValidateIdentity<TManager, TUser>(
      TimeSpan validateInterval,
      Func<TManager, TUser, Task<ClaimsIdentity>> regenerateIdentity)
      where TManager : UserManager<TUser, string>
      where TUser : class, IUser<string>
    {
      return SecurityStampValidator.OnValidateIdentity<TManager, TUser, string>(validateInterval, regenerateIdentity, (Func<ClaimsIdentity, string>) (id => IdentityExtensions.GetUserId((IIdentity) id)));
    }

    /// <summary>
    ///     Can be used as the ValidateIdentity method for a CookieAuthenticationProvider which will check a user's security
    ///     stamp after validateInterval
    ///     Rejects the identity if the stamp changes, and otherwise will call regenerateIdentity to sign in a new
    ///     ClaimsIdentity
    /// </summary>
    /// <typeparam name="TManager"></typeparam>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="validateInterval"></param>
    /// <param name="regenerateIdentityCallback"></param>
    /// <param name="getUserIdCallback"></param>
    /// <returns></returns>
    public static Func<CookieValidateIdentityContext, Task> OnValidateIdentity<TManager, TUser, TKey>(
      TimeSpan validateInterval,
      Func<TManager, TUser, Task<ClaimsIdentity>> regenerateIdentityCallback,
      Func<ClaimsIdentity, TKey> getUserIdCallback)
      where TManager : UserManager<TUser, TKey>
      where TUser : class, IUser<TKey>
      where TKey : IEquatable<TKey>
    {
      if (getUserIdCallback == null)
        throw new ArgumentNullException(nameof (getUserIdCallback));
      return (Func<CookieValidateIdentityContext, Task>) (async context =>
      {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        if (context.Options != null && context.Options.SystemClock != null)
          utcNow = context.Options.SystemClock.UtcNow;
        DateTimeOffset? issuedUtc = context.Properties.IssuedUtc;
        bool flag = !issuedUtc.HasValue;
        if (issuedUtc.HasValue)
          flag = utcNow.Subtract(issuedUtc.Value) > validateInterval;
        if (!flag)
          return;
        TManager manager = context.OwinContext.GetUserManager<TManager>();
        TKey userId = getUserIdCallback(context.Identity);
        if ((object) manager != null && (object) userId != null)
        {
          TUser user = await TaskExtensions.WithCurrentCulture<TUser>(((UserManager<TUser, TKey>) (object) manager).FindByIdAsync(userId));
          bool reject = true;
          if ((object) user != null && ((UserManager<TUser, TKey>) (object) manager).SupportsUserSecurityStamp)
          {
            string str = IdentityExtensions.FindFirstValue(context.Identity, "AspNet.Identity.SecurityStamp");
            if (str == await TaskExtensions.WithCurrentCulture<string>(((UserManager<TUser, TKey>) (object) manager).GetSecurityStampAsync(userId)))
            {
              str = (string) null;
              reject = false;
              if (regenerateIdentityCallback != null)
              {
                ClaimsIdentity claimsIdentity = await TaskExtensions.WithCurrentCulture<ClaimsIdentity>(regenerateIdentityCallback(manager, user));
                if (claimsIdentity != null)
                {
                  context.Properties.IssuedUtc = new DateTimeOffset?();
                  context.Properties.ExpiresUtc = new DateTimeOffset?();
                  context.OwinContext.Authentication.SignIn(context.Properties, claimsIdentity);
                }
              }
            }
          }
          if (reject)
          {
            context.RejectIdentity();
            context.OwinContext.Authentication.SignOut(context.Options.AuthenticationType);
          }
          user = default (TUser);
        }
        manager = default (TManager);
        userId = default (TKey);
      });
    }
  }
}
