// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.EntityStore`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  ///     EntityFramework based IIdentityEntityStore that allows query/manipulation of a TEntity set
  /// </summary>
  /// <typeparam name="TEntity">Concrete entity type, i.e .User</typeparam>
  internal class EntityStore<TEntity> where TEntity : class
  {
    /// <summary>Constructor that takes a Context</summary>
    /// <param name="context"></param>
    public EntityStore(DbContext context)
    {
      this.Context = context;
      this.DbEntitySet = context.Set<TEntity>();
    }

    /// <summary>Context for the store</summary>
    public DbContext Context { get; private set; }

    /// <summary>Used to query the entities</summary>
    public IQueryable<TEntity> EntitySet => (IQueryable<TEntity>) this.DbEntitySet;

    /// <summary>EntitySet for this store</summary>
    public DbSet<TEntity> DbEntitySet { get; private set; }

    /// <summary>FindAsync an entity by ID</summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual Task<TEntity> GetByIdAsync(object id) => this.DbEntitySet.FindAsync(id);

    /// <summary>Insert an entity</summary>
    /// <param name="entity"></param>
    public void Create(TEntity entity) => this.DbEntitySet.Add(entity);

    /// <summary>Mark an entity for deletion</summary>
    /// <param name="entity"></param>
    public void Delete(TEntity entity) => this.DbEntitySet.Remove(entity);

    /// <summary>Update an entity</summary>
    /// <param name="entity"></param>
    public virtual void Update(TEntity entity)
    {
      if ((object) entity == null)
        return;
      this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
    }
  }
}
