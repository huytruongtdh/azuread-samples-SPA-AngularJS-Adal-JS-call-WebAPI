// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IRoleStore`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Interface that exposes basic role management</summary>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public interface IRoleStore<TRole, in TKey> : IDisposable where TRole : IRole<TKey>
  {
    /// <summary>Create a new role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task CreateAsync(TRole role);

    /// <summary>Update a role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task UpdateAsync(TRole role);

    /// <summary>Delete a role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task DeleteAsync(TRole role);

    /// <summary>Find a role by id</summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<TRole> FindByIdAsync(TKey roleId);

    /// <summary>Find a role by name</summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    Task<TRole> FindByNameAsync(string roleName);
  }
}
