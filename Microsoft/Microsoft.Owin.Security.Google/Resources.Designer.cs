// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.Resources
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Owin.Security.Google
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
        if (Microsoft.Owin.Security.Google.Resources.resourceMan == null)
          Microsoft.Owin.Security.Google.Resources.resourceMan = new ResourceManager("Microsoft.Owin.Security.Google.Resources", typeof (Microsoft.Owin.Security.Google.Resources).Assembly);
        return Microsoft.Owin.Security.Google.Resources.resourceMan;
      }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Microsoft.Owin.Security.Google.Resources.resourceCulture;
      set => Microsoft.Owin.Security.Google.Resources.resourceCulture = value;
    }

    /// <summary>
    ///   Looks up a localized string similar to The '{0}' option must be provided..
    /// </summary>
    internal static string Exception_OptionMustBeProvided => Microsoft.Owin.Security.Google.Resources.ResourceManager.GetString(nameof (Exception_OptionMustBeProvided), Microsoft.Owin.Security.Google.Resources.resourceCulture);

    /// <summary>
    ///   Looks up a localized string similar to An ICertificateValidator cannot be specified at the same time as an HttpMessageHandler unless it is a WebRequestHandler..
    /// </summary>
    internal static string Exception_ValidatorHandlerMismatch => Microsoft.Owin.Security.Google.Resources.ResourceManager.GetString(nameof (Exception_ValidatorHandlerMismatch), Microsoft.Owin.Security.Google.Resources.resourceCulture);
  }
}
