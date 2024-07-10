// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IRole`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Mimimal set of data needed to persist role information
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  public interface IRole<out TKey>
  {
    /// <summary>Id of the role</summary>
    TKey Id { get; }

    /// <summary>Name of the role</summary>
    string Name { get; set; }
  }
}
