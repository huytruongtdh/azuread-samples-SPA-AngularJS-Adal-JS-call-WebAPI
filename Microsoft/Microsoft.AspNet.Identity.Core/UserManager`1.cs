// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserManager`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     UserManager for users where the primary key for the User is of type string
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  public class UserManager<TUser> : UserManager<TUser, string> where TUser : class, IUser<string>
  {
    /// <summary>Constructor</summary>
    /// <param name="store"></param>
    public UserManager(IUserStore<TUser> store)
      : base((IUserStore<TUser, string>) store)
    {
    }
  }
}
