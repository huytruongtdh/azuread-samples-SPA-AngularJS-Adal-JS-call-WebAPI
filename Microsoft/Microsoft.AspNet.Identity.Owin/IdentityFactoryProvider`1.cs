// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.IdentityFactoryProvider`1
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin;
using System;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Used to configure how the IdentityFactoryMiddleware will create an instance of the specified type for each OwinContext
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IdentityFactoryProvider<T> : IIdentityFactoryProvider<T> where T : class, IDisposable
  {
    /// <summary>Constructor</summary>
    public IdentityFactoryProvider()
    {
      this.OnDispose = (Action<IdentityFactoryOptions<T>, T>) ((options, instance) => { });
      this.OnCreate = (Func<IdentityFactoryOptions<T>, IOwinContext, T>) ((options, context) => default (T));
    }

    /// <summary>
    ///     A delegate assigned to this property will be invoked when the related method is called
    /// </summary>
    public Func<IdentityFactoryOptions<T>, IOwinContext, T> OnCreate { get; set; }

    /// <summary>
    ///     A delegate assigned to this property will be invoked when the related method is called
    /// </summary>
    public Action<IdentityFactoryOptions<T>, T> OnDispose { get; set; }

    /// <summary>Calls the OnCreate Delegate</summary>
    /// <param name="options"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual T Create(IdentityFactoryOptions<T> options, IOwinContext context) => this.OnCreate(options, context);

    /// <summary>Calls the OnDispose delegate</summary>
    /// <param name="options"></param>
    /// <param name="instance"></param>
    public virtual void Dispose(IdentityFactoryOptions<T> options, T instance) => this.OnDispose(options, instance);
  }
}
