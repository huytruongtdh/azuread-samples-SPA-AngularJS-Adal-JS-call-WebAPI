// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.RoleStore`3
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>EntityFramework based implementation</summary>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TUserRole"></typeparam>
  public class RoleStore<TRole, TKey, TUserRole> : 
    IQueryableRoleStore<TRole, TKey>,
    IRoleStore<TRole, TKey>,
    IDisposable
    where TRole : IdentityRole<TKey, TUserRole>, new()
    where TUserRole : IdentityUserRole<TKey>, new()
  {
    private bool _disposed;
    private EntityStore<TRole> _roleStore;

    /// <summary>
    ///     Constructor which takes a db context and wires up the stores with default instances using the context
    /// </summary>
    /// <param name="context"></param>
    public RoleStore(DbContext context)
    {
      this.Context = context != null ? context : throw new ArgumentNullException(nameof (context));
      this._roleStore = new EntityStore<TRole>(context);
    }

    /// <summary>Context for the store</summary>
    public DbContext Context { get; private set; }

    /// <summary>
    ///     If true will call dispose on the DbContext during Dipose
    /// </summary>
    public bool DisposeContext { get; set; }

    /// <summary>Find a role by id</summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public Task<TRole> FindByIdAsync(TKey roleId)
    {
      this.ThrowIfDisposed();
      return this._roleStore.GetByIdAsync((object) roleId);
    }

    /// <summary>Find a role by name</summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public Task<TRole> FindByNameAsync(string roleName)
    {
      this.ThrowIfDisposed();
      return this._roleStore.EntitySet.FirstOrDefaultAsync<TRole>((Expression<Func<TRole, bool>>) (u => u.Name.ToUpper() == roleName.ToUpper()));
    }

    /// <summary>Insert an entity</summary>
    /// <param name="role"></param>
    public virtual async Task CreateAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      this._roleStore.Create(role);
      int num = await this.Context.SaveChangesAsync().WithCurrentCulture<int>();
    }

    /// <summary>Mark an entity for deletion</summary>
    /// <param name="role"></param>
    public virtual async Task DeleteAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      this._roleStore.Delete(role);
      int num = await this.Context.SaveChangesAsync().WithCurrentCulture<int>();
    }

    /// <summary>Update an entity</summary>
    /// <param name="role"></param>
    public virtual async Task UpdateAsync(TRole role)
    {
      this.ThrowIfDisposed();
      if ((object) role == null)
        throw new ArgumentNullException(nameof (role));
      this._roleStore.Update(role);
      int num = await this.Context.SaveChangesAsync().WithCurrentCulture<int>();
    }

    /// <summary>Returns an IQueryable of users</summary>
    public IQueryable<TRole> Roles => this._roleStore.EntitySet;

    /// <summary>Dispose the store</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void ThrowIfDisposed()
    {
      if (this._disposed)
        throw new ObjectDisposedException(this.GetType().Name);
    }

    /// <summary>
    ///     If disposing, calls dispose on the Context.  Always nulls out the Context
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (this.DisposeContext & disposing && this.Context != null)
        this.Context.Dispose();
      this._disposed = true;
      this.Context = (DbContext) null;
      this._roleStore = (EntityStore<TRole>) null;
    }
  }
}
