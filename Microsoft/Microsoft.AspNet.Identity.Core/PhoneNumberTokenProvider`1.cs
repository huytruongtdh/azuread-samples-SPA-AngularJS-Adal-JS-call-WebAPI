// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.PhoneNumberTokenProvider`1
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>
  ///     TokenProvider that generates tokens from the user's security stamp and notifies a user via their phone number
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  public class PhoneNumberTokenProvider<TUser> : PhoneNumberTokenProvider<TUser, string> where TUser : class, IUser<string>
  {
  }
}
