// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.IIdentityFactoryProvider`1
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin;
using System;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>Interface used to create objects per request</summary>
  /// <typeparam name="T"></typeparam>
  public interface IIdentityFactoryProvider<T> where T : IDisposable
  {
    /// <summary>Called once per request to create an object</summary>
    /// <param name="options"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    T Create(IdentityFactoryOptions<T> options, IOwinContext context);

    /// <summary>
    ///     Called at the end of the request to dispose the object created
    /// </summary>
    /// <param name="options"></param>
    /// <param name="instance"></param>
    void Dispose(IdentityFactoryOptions<T> options, T instance);
  }
}
