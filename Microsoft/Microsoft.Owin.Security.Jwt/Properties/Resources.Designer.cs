// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.Properties.Resources
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Owin.Security.Jwt.Properties
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
        if (Microsoft.Owin.Security.Jwt.Properties.Resources.resourceMan == null)
          Microsoft.Owin.Security.Jwt.Properties.Resources.resourceMan = new ResourceManager("Microsoft.Owin.Security.Jwt.Properties.Resources", typeof (Microsoft.Owin.Security.Jwt.Properties.Resources).Assembly);
        return Microsoft.Owin.Security.Jwt.Properties.Resources.resourceMan;
      }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture;
      set => Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture = value;
    }

    /// <summary>
    ///   Looks up a localized string similar to One or more audiences must be specified..
    /// </summary>
    internal static string Exception_AudiencesMustBeSpecified => Microsoft.Owin.Security.Jwt.Properties.Resources.ResourceManager.GetString(nameof (Exception_AudiencesMustBeSpecified), Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to JWT does not contain an issuer and ValidateIssuer=true..
    /// </summary>
    internal static string Exception_CannotValidateIssuer => Microsoft.Owin.Security.Jwt.Properties.Resources.ResourceManager.GetString(nameof (Exception_CannotValidateIssuer), Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Invalid JWT..
    /// </summary>
    internal static string Exception_InvalidJwt => Microsoft.Owin.Security.Jwt.Properties.Resources.ResourceManager.GetString(nameof (Exception_InvalidJwt), Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to One or more issuer credential providers must be specified..
    /// </summary>
    internal static string Exception_IssuerCredentialProvidersMustBeSpecified => Microsoft.Owin.Security.Jwt.Properties.Resources.ResourceManager.GetString(nameof (Exception_IssuerCredentialProvidersMustBeSpecified), Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to Issuer not known..
    /// </summary>
    internal static string Exception_UnknownIssuer => Microsoft.Owin.Security.Jwt.Properties.Resources.ResourceManager.GetString(nameof (Exception_UnknownIssuer), Microsoft.Owin.Security.Jwt.Properties.Resources.resourceCulture);
  }
}
