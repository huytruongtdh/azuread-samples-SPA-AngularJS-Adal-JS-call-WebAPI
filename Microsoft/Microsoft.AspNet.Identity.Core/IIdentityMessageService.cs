// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IIdentityMessageService
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Expose a way to send messages (i.e. email/sms)</summary>
  public interface IIdentityMessageService
  {
    /// <summary>This method should send the message</summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendAsync(IdentityMessage message);
  }
}
