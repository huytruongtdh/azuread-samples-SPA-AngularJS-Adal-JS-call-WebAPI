// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IdentityExtensions
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Extensions making it easier to get the user name/user id claims off of an identity
  /// </summary>
  public static class IdentityExtensions
  {
    /// <summary>Return the user name using the UserNameClaimType</summary>
    /// <param name="identity"></param>
    /// <returns></returns>
    public static string GetUserName(this IIdentity identity)
    {
      if (identity == null)
        throw new ArgumentNullException(nameof (identity));
      return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name") : (string) null;
    }

    /// <summary>Return the user id using the UserIdClaimType</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="identity"></param>
    /// <returns></returns>
    public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
    {
      if (identity == null)
        throw new ArgumentNullException(nameof (identity));
      if (identity is ClaimsIdentity identity1)
      {
        string firstValue = identity1.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        if (firstValue != null)
          return (T) Convert.ChangeType((object) firstValue, typeof (T), (IFormatProvider) CultureInfo.InvariantCulture);
      }
      return default (T);
    }

    /// <summary>Return the user id using the UserIdClaimType</summary>
    /// <param name="identity"></param>
    /// <returns></returns>
    public static string GetUserId(this IIdentity identity)
    {
      if (identity == null)
        throw new ArgumentNullException(nameof (identity));
      return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") : (string) null;
    }

    /// <summary>
    ///     Return the claim value for the first claim with the specified type if it exists, null otherwise
    /// </summary>
    /// <param name="identity"></param>
    /// <param name="claimType"></param>
    /// <returns></returns>
    public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
    {
      if (identity == null)
        throw new ArgumentNullException(nameof (identity));
      return identity.FindFirst(claimType)?.Value;
    }
  }
}
