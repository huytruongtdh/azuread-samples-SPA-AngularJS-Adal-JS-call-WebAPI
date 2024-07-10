// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.RoleManagerExtensions
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Extension methods for RoleManager</summary>
  public static class RoleManagerExtensions
  {
    /// <summary>Find a role by id</summary>
    /// <param name="manager"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public static TRole FindById<TRole, TKey>(this RoleManager<TRole, TKey> manager, TKey roleId)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TRole>((Func<Task<TRole>>) (() => manager.FindByIdAsync(roleId))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Find a role by name</summary>
    /// <param name="manager"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public static TRole FindByName<TRole, TKey>(
      this RoleManager<TRole, TKey> manager,
      string roleName)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<TRole>((Func<Task<TRole>>) (() => manager.FindByNameAsync(roleName))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Create a role</summary>
    /// <param name="manager"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IdentityResult Create<TRole, TKey>(
      this RoleManager<TRole, TKey> manager,
      TRole role)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.CreateAsync(role))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Update an existing role</summary>
    /// <param name="manager"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IdentityResult Update<TRole, TKey>(
      this RoleManager<TRole, TKey> manager,
      TRole role)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.UpdateAsync(role))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Delete a role</summary>
    /// <param name="manager"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IdentityResult Delete<TRole, TKey>(
      this RoleManager<TRole, TKey> manager,
      TRole role)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<IdentityResult>((Func<Task<IdentityResult>>) (() => manager.DeleteAsync(role))) : throw new ArgumentNullException(nameof (manager));
    }

    /// <summary>Returns true if the role exists</summary>
    /// <param name="manager"></param>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public static bool RoleExists<TRole, TKey>(
      this RoleManager<TRole, TKey> manager,
      string roleName)
      where TRole : class, IRole<TKey>
      where TKey : IEquatable<TKey>
    {
      return manager != null ? AsyncHelper.RunSync<bool>((Func<Task<bool>>) (() => manager.RoleExistsAsync(roleName))) : throw new ArgumentNullException(nameof (manager));
    }
  }
}
