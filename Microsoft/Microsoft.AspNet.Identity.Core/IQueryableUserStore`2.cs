// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IQueryableUserStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Linq;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that exposes an IQueryable users</summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IQueryableUserStore<TUser, in TKey> : IUserStore<TUser, TKey>, IDisposable where TUser : class, IUser<TKey>
  {
    /// <summary>IQueryable users</summary>
    IQueryable<TUser> Users { get; }
  }
}
