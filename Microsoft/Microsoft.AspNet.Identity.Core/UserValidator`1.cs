// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserValidator`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Validates users before they are saved</summary>
  /// <typeparam name="TUser"></typeparam>
  public class UserValidator<TUser> : UserValidator<TUser, string> where TUser : class, IUser<string>
  {
    /// <summary>Constructor</summary>
    /// <param name="manager"></param>
    public UserValidator(UserManager<TUser, string> manager)
      : base(manager)
    {
    }
  }
}
