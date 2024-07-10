// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.TaskExtensions
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  public static class TaskExtensions
  {
    public static TaskExtensions.CultureAwaiter<T> WithCurrentCulture<T>(this Task<T> task) => new TaskExtensions.CultureAwaiter<T>(task);

    public static TaskExtensions.CultureAwaiter WithCurrentCulture(this Task task) => new TaskExtensions.CultureAwaiter(task);

    public struct CultureAwaiter<T> : ICriticalNotifyCompletion, INotifyCompletion
    {
      private readonly Task<T> _task;

      public CultureAwaiter(Task<T> task) => this._task = task;

      public TaskExtensions.CultureAwaiter<T> GetAwaiter() => this;

      public bool IsCompleted => this._task.IsCompleted;

      public T GetResult() => this._task.GetAwaiter().GetResult();

      public void OnCompleted(Action continuation) => throw new NotImplementedException();

      public void UnsafeOnCompleted(Action continuation)
      {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        this._task.ConfigureAwait(false).GetAwaiter().UnsafeOnCompleted((Action) (() =>
        {
          CultureInfo currentCulture1 = Thread.CurrentThread.CurrentCulture;
          CultureInfo currentUiCulture1 = Thread.CurrentThread.CurrentUICulture;
          Thread.CurrentThread.CurrentCulture = currentCulture;
          Thread.CurrentThread.CurrentUICulture = currentUiCulture;
          try
          {
            continuation();
          }
          finally
          {
            Thread.CurrentThread.CurrentCulture = currentCulture1;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture1;
          }
        }));
      }
    }

    public struct CultureAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
      private readonly Task _task;

      public CultureAwaiter(Task task) => this._task = task;

      public TaskExtensions.CultureAwaiter GetAwaiter() => this;

      public bool IsCompleted => this._task.IsCompleted;

      public void GetResult() => this._task.GetAwaiter().GetResult();

      public void OnCompleted(Action continuation) => throw new NotImplementedException();

      public void UnsafeOnCompleted(Action continuation)
      {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        this._task.ConfigureAwait(false).GetAwaiter().UnsafeOnCompleted((Action) (() =>
        {
          CultureInfo currentCulture1 = Thread.CurrentThread.CurrentCulture;
          CultureInfo currentUiCulture1 = Thread.CurrentThread.CurrentUICulture;
          Thread.CurrentThread.CurrentCulture = currentCulture;
          Thread.CurrentThread.CurrentUICulture = currentUiCulture;
          try
          {
            continuation();
          }
          finally
          {
            Thread.CurrentThread.CurrentCulture = currentCulture1;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture1;
          }
        }));
      }
    }
  }
}
