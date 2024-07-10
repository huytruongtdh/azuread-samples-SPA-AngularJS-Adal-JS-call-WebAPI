// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IQueryableRoleStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Linq;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that exposes an IQueryable roles</summary>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IQueryableRoleStore<TRole, in TKey> : IRoleStore<TRole, TKey>, IDisposable where TRole : IRole<TKey>
  {
    /// <summary>IQueryable Roles</summary>
    IQueryable<TRole> Roles { get; }
  }
}
