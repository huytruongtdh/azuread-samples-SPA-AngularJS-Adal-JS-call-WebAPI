// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.AsyncHelper
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  public static class AsyncHelper
  {
    private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
    {
      CultureInfo cultureUi = CultureInfo.CurrentUICulture;
      CultureInfo culture = CultureInfo.CurrentCulture;
      return AsyncHelper._myTaskFactory.StartNew<Task<TResult>>((Func<Task<TResult>>) (() =>
      {
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = cultureUi;
        return func();
      })).Unwrap<TResult>().GetAwaiter().GetResult();
    }

    public static void RunSync(Func<Task> func)
    {
      CultureInfo cultureUi = CultureInfo.CurrentUICulture;
      CultureInfo culture = CultureInfo.CurrentCulture;
      AsyncHelper._myTaskFactory.StartNew<Task>((Func<Task>) (() =>
      {
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = cultureUi;
        return func();
      })).Unwrap().GetAwaiter().GetResult();
    }
  }
}
