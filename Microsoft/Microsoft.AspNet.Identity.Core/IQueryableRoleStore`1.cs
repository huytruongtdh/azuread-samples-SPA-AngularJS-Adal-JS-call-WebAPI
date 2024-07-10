// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IQueryableRoleStore`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that exposes an IQueryable roles</summary>
  /// <typeparam name="TRole"></typeparam>
  public interface IQueryableRoleStore<TRole> : 
    IQueryableRoleStore<TRole, string>,
    IRoleStore<TRole, string>,
    IDisposable
    where TRole : IRole<string>
  {
  }
}
