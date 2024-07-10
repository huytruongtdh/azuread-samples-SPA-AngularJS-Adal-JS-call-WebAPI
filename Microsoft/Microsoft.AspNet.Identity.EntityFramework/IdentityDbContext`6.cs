// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext`6
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  /// Generic IdentityDbContext base that can be customized with entity types that extend from the base IdentityUserXXX types.
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  /// <typeparam name="TRole"></typeparam>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TUserLogin"></typeparam>
  /// <typeparam name="TUserRole"></typeparam>
  /// <typeparam name="TUserClaim"></typeparam>
  public class IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> : DbContext
    where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>
    where TRole : IdentityRole<TKey, TUserRole>
    where TUserLogin : IdentityUserLogin<TKey>
    where TUserRole : IdentityUserRole<TKey>
    where TUserClaim : IdentityUserClaim<TKey>
  {
    /// <summary>
    ///     Default constructor which uses the "DefaultConnection" connectionString
    /// </summary>
    public IdentityDbContext()
      : this("DefaultConnection")
    {
    }

    /// <summary>
    ///     Constructor which takes the connection string to use
    /// </summary>
    /// <param name="nameOrConnectionString"></param>
    public IdentityDbContext(string nameOrConnectionString)
      : base(nameOrConnectionString)
    {
    }

    /// <summary>
    ///     Constructs a new context instance using the existing connection to connect to a database, and initializes it from
    ///     the given model.  The connection will not be disposed when the context is disposed if contextOwnsConnection is
    ///     false.
    /// </summary>
    /// <param name="existingConnection">An existing connection to use for the new context.</param>
    /// <param name="model">The model that will back this context.</param>
    /// <param name="contextOwnsConnection">
    ///     Constructs a new context instance using the existing connection to connect to a
    ///     database, and initializes it from the given model.  The connection will not be disposed when the context is
    ///     disposed if contextOwnsConnection is false.
    /// </param>
    public IdentityDbContext(
      DbConnection existingConnection,
      DbCompiledModel model,
      bool contextOwnsConnection)
      : base(existingConnection, model, contextOwnsConnection)
    {
    }

    /// <summary>
    ///     Constructs a new context instance using conventions to create the name of
    ///     the database to which a connection will be made, and initializes it from
    ///     the given model.  The by-convention name is the full name (namespace + class
    ///     name) of the derived context class.  See the class remarks for how this is
    ///     used to create a connection.
    /// </summary>
    /// <param name="model">The model that will back this context.</param>
    public IdentityDbContext(DbCompiledModel model)
      : base(model)
    {
    }

    /// <summary>
    ///     Constructs a new context instance using the existing connection to connect
    ///     to a database.  The connection will not be disposed when the context is disposed
    ///     if contextOwnsConnection is false.
    /// </summary>
    /// <param name="existingConnection">An existing connection to use for the new context.</param>
    /// <param name="contextOwnsConnection">If set to true the connection is disposed when the context is disposed, otherwise
    ///     the caller must dispose the connection.
    /// </param>
    public IdentityDbContext(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
    {
    }

    /// <summary>
    ///     Constructs a new context instance using the given string as the name or connection
    ///     string for the database to which a connection will be made, and initializes
    ///     it from the given model.  See the class remarks for how this is used to create
    ///     a connection.
    /// </summary>
    /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
    /// <param name="model">The model that will back this context.</param>
    public IdentityDbContext(string nameOrConnectionString, DbCompiledModel model)
      : base(nameOrConnectionString, model)
    {
    }

    /// <summary>IDbSet of Users</summary>
    public virtual IDbSet<TUser> Users { get; set; }

    /// <summary>IDbSet of Roles</summary>
    public virtual IDbSet<TRole> Roles { get; set; }

    /// <summary>If true validates that emails are unique</summary>
    public bool RequireUniqueEmail { get; set; }

    /// <summary>
    ///     Maps table names, and sets up relationships between the various user entities
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      EntityTypeConfiguration<TUser> typeConfiguration = modelBuilder != null ? modelBuilder.Entity<TUser>().ToTable("AspNetUsers") : throw new ArgumentNullException(nameof (modelBuilder));
      typeConfiguration.HasMany<TUserRole>((Expression<Func<TUser, ICollection<TUserRole>>>) (u => u.Roles)).WithRequired().HasForeignKey<TKey>((Expression<Func<TUserRole, TKey>>) (ur => ur.UserId));
      typeConfiguration.HasMany<TUserClaim>((Expression<Func<TUser, ICollection<TUserClaim>>>) (u => u.Claims)).WithRequired().HasForeignKey<TKey>((Expression<Func<TUserClaim, TKey>>) (uc => uc.UserId));
      typeConfiguration.HasMany<TUserLogin>((Expression<Func<TUser, ICollection<TUserLogin>>>) (u => u.Logins)).WithRequired().HasForeignKey<TKey>((Expression<Func<TUserLogin, TKey>>) (ul => ul.UserId));
      typeConfiguration.Property((Expression<Func<TUser, string>>) (u => u.UserName)).IsRequired().HasMaxLength(new int?(256)).HasColumnAnnotation("Index", (object) new IndexAnnotation(new IndexAttribute("UserNameIndex")
      {
        IsUnique = true
      }));
      typeConfiguration.Property((Expression<Func<TUser, string>>) (u => u.Email)).HasMaxLength(new int?(256));
      modelBuilder.Entity<TUserRole>().HasKey(r => new
      {
        UserId = r.UserId,
        RoleId = r.RoleId
      }).ToTable("AspNetUserRoles");
      modelBuilder.Entity<TUserLogin>().HasKey(l => new
      {
        LoginProvider = l.LoginProvider,
        ProviderKey = l.ProviderKey,
        UserId = l.UserId
      }).ToTable("AspNetUserLogins");
      modelBuilder.Entity<TUserClaim>().ToTable("AspNetUserClaims");
      EntityTypeConfiguration<TRole> table = modelBuilder.Entity<TRole>().ToTable("AspNetRoles");
      table.Property((Expression<Func<TRole, string>>) (r => r.Name)).IsRequired().HasMaxLength(new int?(256)).HasColumnAnnotation("Index", (object) new IndexAnnotation(new IndexAttribute("RoleNameIndex")
      {
        IsUnique = true
      }));
      table.HasMany<TUserRole>((Expression<Func<TRole, ICollection<TUserRole>>>) (r => r.Users)).WithRequired().HasForeignKey<TKey>((Expression<Func<TUserRole, TKey>>) (ur => ur.RoleId));
    }

    /// <summary>
    ///     Validates that UserNames are unique and case insenstive
    /// </summary>
    /// <param name="entityEntry"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    protected override DbEntityValidationResult ValidateEntity(
      DbEntityEntry entityEntry,
      IDictionary<object, object> items)
    {
      if (entityEntry != null && entityEntry.State == EntityState.Added)
      {
        List<DbValidationError> dbValidationErrorList = new List<DbValidationError>();
        TUser user = entityEntry.Entity as TUser;
        if ((object) user != null)
        {
          if (this.Users.Any<TUser>((Expression<Func<TUser, bool>>) (u => string.Equals(u.UserName, user.UserName))))
            dbValidationErrorList.Add(new DbValidationError("User", string.Format((IFormatProvider) CultureInfo.CurrentCulture, IdentityResources.DuplicateUserName, (object) user.UserName)));
          if (this.RequireUniqueEmail)
          {
            if (this.Users.Any<TUser>((Expression<Func<TUser, bool>>) (u => string.Equals(u.Email, user.Email))))
              dbValidationErrorList.Add(new DbValidationError("User", string.Format((IFormatProvider) CultureInfo.CurrentCulture, IdentityResources.DuplicateEmail, (object) user.Email)));
          }
        }
        else
        {
          TRole role = entityEntry.Entity as TRole;
          if ((object) role != null)
          {
            if (this.Roles.Any<TRole>((Expression<Func<TRole, bool>>) (r => string.Equals(r.Name, role.Name))))
              dbValidationErrorList.Add(new DbValidationError("Role", string.Format((IFormatProvider) CultureInfo.CurrentCulture, IdentityResources.RoleAlreadyExists, (object) role.Name)));
          }
        }
        if (dbValidationErrorList.Any<DbValidationError>())
          return new DbEntityValidationResult(entityEntry, (IEnumerable<DbValidationError>) dbValidationErrorList);
      }
      return base.ValidateEntity(entityEntry, items);
    }
  }
}
