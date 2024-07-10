﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IUser`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Minimal interface for a user with id and username</summary>
  /// <typeparam name="TKey"></typeparam>
  public interface IUser<out TKey>
  {
    /// <summary>Unique key for the user</summary>
    TKey Id { get; }

    /// <summary>Unique username</summary>
    string UserName { get; set; }
  }
}
