// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.OwinContextExtensions
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin;
using System;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>Extension methods for OwinContext/&gt;</summary>
  public static class OwinContextExtensions
  {
    private static readonly string IdentityKeyPrefix = "AspNet.Identity.Owin:";

    private static string GetKey(Type t) => OwinContextExtensions.IdentityKeyPrefix + t.AssemblyQualifiedName;

    /// <summary>
    ///     Stores an object in the OwinContext using a key based on the AssemblyQualified type name
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IOwinContext Set<T>(this IOwinContext context, T value) => context != null ? context.Set<T>(OwinContextExtensions.GetKey(typeof (T)), value) : throw new ArgumentNullException(nameof (context));

    /// <summary>
    ///     Retrieves an object from the OwinContext using a key based on the AssemblyQualified type name
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    /// <returns></returns>
    public static T Get<T>(this IOwinContext context) => context != null ? context.Get<T>(OwinContextExtensions.GetKey(typeof (T))) : throw new ArgumentNullException(nameof (context));

    /// <summary>Get the user manager from the context</summary>
    /// <typeparam name="TManager"></typeparam>
    /// <param name="context"></param>
    /// <returns></returns>
    public static TManager GetUserManager<TManager>(this IOwinContext context) => context != null ? context.Get<TManager>() : throw new ArgumentNullException(nameof (context));
  }
}
