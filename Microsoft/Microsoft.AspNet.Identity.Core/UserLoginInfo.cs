// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.UserLoginInfo
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     Represents a linked login for a user (i.e. a facebook/google account)
  /// </summary>
  public sealed class UserLoginInfo
  {
    /// <summary>Constructor</summary>
    /// <param name="loginProvider"></param>
    /// <param name="providerKey"></param>
    public UserLoginInfo(string loginProvider, string providerKey)
    {
      this.LoginProvider = loginProvider;
      this.ProviderKey = providerKey;
    }

    /// <summary>
    ///     Provider for the linked login, i.e. Facebook, Google, etc.
    /// </summary>
    public string LoginProvider { get; set; }

    /// <summary>User specific key for the login provider</summary>
    public string ProviderKey { get; set; }
  }
}
