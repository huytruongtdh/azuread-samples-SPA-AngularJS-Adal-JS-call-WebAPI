﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin`1
// Assembly: Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F4977326-DE62-4E75-AC98-400B9ADDC192
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.EntityFramework.xml

namespace Microsoft.AspNet.Identity.EntityFramework
{
  /// <summary>
  ///     Entity type for a user's login (i.e. facebook, google)
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  public class IdentityUserLogin<TKey>
  {
    /// <summary>
    ///     The login provider for the login (i.e. facebook, google)
    /// </summary>
    public virtual string LoginProvider { get; set; }

    /// <summary>Key representing the login for the provider</summary>
    public virtual string ProviderKey { get; set; }

    /// <summary>User Id for the user who owns this login</summary>
    public virtual TKey UserId { get; set; }
  }
}
