// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>EntityType that represents one specific user claim</summary>
  /// <typeparam name="TKey"></typeparam>
  public class IdentityUserClaim<TKey>
  {
    /// <summary>Primary key</summary>
    public virtual int Id { get; set; }

    /// <summary>User Id for the user who owns this login</summary>
    public virtual TKey UserId { get; set; }

    /// <summary>Claim type</summary>
    public virtual string ClaimType { get; set; }

    /// <summary>Claim value</summary>
    public virtual string ClaimValue { get; set; }
  }
}
