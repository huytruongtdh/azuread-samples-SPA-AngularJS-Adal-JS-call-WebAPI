// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.IdentityFactoryOptions`1
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin.Security.DataProtection;
using System;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Configuration options for a IdentityFactoryMiddleware
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IdentityFactoryOptions<T> where T : IDisposable
  {
    /// <summary>Used to configure the data protection provider</summary>
    public IDataProtectionProvider DataProtectionProvider { get; set; }

    /// <summary>Provider used to Create and Dispose objects</summary>
    public IIdentityFactoryProvider<T> Provider { get; set; }
  }
}
