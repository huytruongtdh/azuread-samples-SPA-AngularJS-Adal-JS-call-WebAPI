// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Resources
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///   A strongly-typed resource class, for looking up localized strings, etc.
  /// </summary>
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Microsoft.AspNet.Identity.Resources.resourceMan == null)
          Microsoft.AspNet.Identity.Resources.resourceMan = new ResourceManager("Microsoft.AspNet.Identity.Resources", typeof (Microsoft.AspNet.Identity.Resources).Assembly);
        return Microsoft.AspNet.Identity.Resources.resourceMan;
      }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Microsoft.AspNet.Identity.Resources.resourceCulture;
      set => Microsoft.AspNet.Identity.Resources.resourceCulture = value;
    }

    /// <summary>
    ///   Looks up a localized string similar to An unknown failure has occured..
    /// </summary>
    internal static string DefaultError => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (DefaultError), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Email '{0}' is already taken..
    /// </summary>
    internal static string DuplicateEmail => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (DuplicateEmail), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Name {0} is already taken..
    /// </summary>
    internal static string DuplicateName => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (DuplicateName), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to A user with that external login already exists..
    /// </summary>
    internal static string ExternalLoginExists => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (ExternalLoginExists), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Email '{0}' is invalid..
    /// </summary>
    internal static string InvalidEmail => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (InvalidEmail), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Invalid token..
    /// </summary>
    internal static string InvalidToken => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (InvalidToken), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to User name {0} is invalid, can only contain letters or digits..
    /// </summary>
    internal static string InvalidUserName => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (InvalidUserName), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Lockout is not enabled for this user..
    /// </summary>
    internal static string LockoutNotEnabled => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (LockoutNotEnabled), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to No IUserTokenProvider is registered..
    /// </summary>
    internal static string NoTokenProvider => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (NoTokenProvider), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to No IUserTwoFactorProvider for '{0}' is registered..
    /// </summary>
    internal static string NoTwoFactorProvider => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (NoTwoFactorProvider), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Incorrect password..
    /// </summary>
    internal static string PasswordMismatch => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordMismatch), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Passwords must have at least one digit ('0'-'9')..
    /// </summary>
    internal static string PasswordRequireDigit => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordRequireDigit), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Passwords must have at least one lowercase ('a'-'z')..
    /// </summary>
    internal static string PasswordRequireLower => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordRequireLower), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Passwords must have at least one non letter or digit character..
    /// </summary>
    internal static string PasswordRequireNonLetterOrDigit => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordRequireNonLetterOrDigit), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Passwords must have at least one uppercase ('A'-'Z')..
    /// </summary>
    internal static string PasswordRequireUpper => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordRequireUpper), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Passwords must be at least {0} characters..
    /// </summary>
    internal static string PasswordTooShort => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PasswordTooShort), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to {0} cannot be null or empty..
    /// </summary>
    internal static string PropertyTooShort => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (PropertyTooShort), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Role {0} does not exist..
    /// </summary>
    internal static string RoleNotFound => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (RoleNotFound), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IQueryableRoleStore&lt;TRole&gt;..
    /// </summary>
    internal static string StoreNotIQueryableRoleStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIQueryableRoleStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IQueryableUserStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIQueryableUserStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIQueryableUserStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserClaimStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserClaimStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserClaimStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserConfirmationStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserConfirmationStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserConfirmationStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserEmailStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserEmailStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserEmailStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserLockoutStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserLockoutStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserLockoutStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserLoginStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserLoginStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserLoginStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserPasswordStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserPasswordStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserPasswordStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserPhoneNumberStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserPhoneNumberStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserPhoneNumberStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserRoleStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserRoleStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserRoleStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserSecurityStampStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserSecurityStampStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserSecurityStampStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Store does not implement IUserTwoFactorStore&lt;TUser&gt;..
    /// </summary>
    internal static string StoreNotIUserTwoFactorStore => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (StoreNotIUserTwoFactorStore), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to User already has a password set..
    /// </summary>
    internal static string UserAlreadyHasPassword => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (UserAlreadyHasPassword), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to User already in role..
    /// </summary>
    internal static string UserAlreadyInRole => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (UserAlreadyInRole), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to UserId not found..
    /// </summary>
    internal static string UserIdNotFound => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (UserIdNotFound), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to User {0} does not exist..
    /// </summary>
    internal static string UserNameNotFound => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (UserNameNotFound), Microsoft.AspNet.Identity.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to User is not in role..
    /// </summary>
    internal static string UserNotInRole => Microsoft.AspNet.Identity.Resources.ResourceManager.GetString(nameof (UserNotInRole), Microsoft.AspNet.Identity.Resources.resourceCulture);
  }
}
