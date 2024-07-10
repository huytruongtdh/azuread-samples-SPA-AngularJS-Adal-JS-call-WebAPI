// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.IdentityFactoryMiddleware`2
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     OwinMiddleware that initializes an object for use in the OwinContext via the Get/Set generic extensions method
  /// </summary>
  /// <typeparam name="TResult"></typeparam>
  /// <typeparam name="TOptions"></typeparam>
  public class IdentityFactoryMiddleware<TResult, TOptions> : OwinMiddleware
    where TResult : IDisposable
    where TOptions : IdentityFactoryOptions<TResult>
  {
    /// <summary>Constructor</summary>
    /// <param name="next">The next middleware in the OWIN pipeline to invoke</param>
    /// <param name="options">Configuration options for the middleware</param>
    public IdentityFactoryMiddleware(OwinMiddleware next, TOptions options)
      : base(next)
    {
      if ((object) options == null)
        throw new ArgumentNullException(nameof (options));
      this.Options = options.Provider != null ? options : throw new ArgumentNullException("options.Provider");
    }

    /// <summary>Configuration options</summary>
    public TOptions Options { get; private set; }

    /// <summary>
    ///     Create an object using the Options.Provider, storing it in the OwinContext and then disposes the object when finished
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task Invoke(IOwinContext context)
    {
      IdentityFactoryMiddleware<TResult, TOptions> factoryMiddleware = this;
      TResult instance = factoryMiddleware.Options.Provider.Create((IdentityFactoryOptions<TResult>) factoryMiddleware.Options, context);
      try
      {
        context.Set<TResult>(instance);
        if (factoryMiddleware.Next == null)
          return;
        await factoryMiddleware.Next.Invoke(context);
      }
      finally
      {
        factoryMiddleware.Options.Provider.Dispose((IdentityFactoryOptions<TResult>) factoryMiddleware.Options, instance);
      }
    }
  }
}
