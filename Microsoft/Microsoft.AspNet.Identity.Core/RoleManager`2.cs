// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.RoleManager`2
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Exposes role related api which will automatically save changes to the RoleStore
  /// </summary>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  public class RoleManager<TRole, TKey> : IDisposable
    where TRole : class, IRole<TKey>
    where TKey : IEquatable<TKey>
  {
    private bool _disposed;
    private IIdentityValidator<TRole> _roleValidator;

    /// <summary>Constructor</summary>
    /// <param name="store">The IRoleStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods</param>
    public RoleManager(IRoleStore<TRole, TKey> store)
    {
      this.Store = store != null ? store : throw new ArgumentNullException(nameof (store));
      this.RoleValidator = (IIdentityValidator<TRole>) new Microsoft.AspNet.Identity.RoleValidator<TRole, TKey>(this);
    }

    /// <summary>
    ///     Persistence abstraction that the Manager operates against
    /// </summary>
    protected IRoleStore<TRole, TKey> Store { get; private set; }

    /// <summary>Used to validate roles before persisting changes</summary>
    public IIdentityValidator<TRole> RoleValidator
    {
      get => this._roleValidator;
      set => this._roleValidator = value != null ? value : throw new ArgumentNullException(nameof (value));
    }

    /// <summary>
    ///     Returns an IQueryable of roles if the store is an IQueryableRoleStore
    /// </summary>
    public virtual IQueryable<TRole> Roles => this.Store is IQueryableRoleStore<TRole, TKey> store ? store.Roles : throw new NotSupportedException(Resources.StoreNotIQueryableRoleStore);

    /// <summary>Dispose this object</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>Create a role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> CreateAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      IdentityResult async = await this.RoleValidator.ValidateAsync(role).WithCurrentCulture<IdentityResult>();
      if (!async.Succeeded)
        return async;
      await this.Store.CreateAsync(role).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Update an existing role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> UpdateAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      IdentityResult identityResult = await this.RoleValidator.ValidateAsync(role).WithCurrentCulture<IdentityResult>();
      if (!identityResult.Succeeded)
        return identityResult;
      await this.Store.UpdateAsync(role).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Delete a role</summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public virtual async Task<IdentityResult> DeleteAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      await this.Store.DeleteAsync(role).WithCurrentCulture();
      return IdentityResult.Success;
    }

    /// <summary>Returns true if the role exists</summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public virtual async Task<bool> RoleExistsAsync(string roleName)
    {
      this.ThrowIfDisposed();
      if (roleName == null)
        throw new ArgumentNullException(nameof (roleName));
      return (object) await this.FindByNameAsync(roleName).WithCurrentCulture<TRole>() != null;
    }

    /// <summary>Find a role by id</summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public virtual async Task<TRole> FindByIdAsync(TKey roleId)
    {
      this.ThrowIfDisposed();
      return await this.Store.FindByIdAsync(roleId).WithCurrentCulture<TRole>();
    }

    /// <summary>Find a role by name</summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public virtual async Task<TRole> FindByNameAsync(string roleName)
    {
      this.ThrowIfDisposed();
      if (roleName == null)
        throw new ArgumentNullException(nameof (roleName));
      return await this.Store.FindByNameAsync(roleName).WithCurrentCulture<TRole>();
    }

    private void ThrowIfDisposed()
    {
      if (this._disposed)
        throw new ObjectDisposedException(this.GetType().Name);
    }

    /// <summary>When disposing, actually dipose the store</summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (disposing && !this._disposed)
        this.Store.Dispose();
      this._disposed = true;
    }
  }
}
