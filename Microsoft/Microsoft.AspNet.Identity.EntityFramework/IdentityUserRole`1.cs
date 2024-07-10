// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  ///     EntityType that represents a user belonging to a role
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  public class IdentityUserRole<TKey>
  {
    /// <summary>UserId for the user that is in the role</summary>
    public virtual TKey UserId { get; set; }

    /// <summary>RoleId for the role</summary>
    public virtual TKey RoleId { get; set; }
  }
}
