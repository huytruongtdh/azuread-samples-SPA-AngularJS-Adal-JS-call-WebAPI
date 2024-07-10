// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IIdentityMessageServiceExtensions
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
  public static class IIdentityMessageServiceExtensions
  {
    /// <summary>Sync method to send the IdentityMessage</summary>
    /// <param name="service"></param>
    /// <param name="message"></param>
    public static void Send(this IIdentityMessageService service, IdentityMessage message)
    {
      if (service == null)
        throw new ArgumentNullException(nameof (service));
      AsyncHelper.RunSync((Func<Task>) (() => service.SendAsync(message)));
    }
  }
}
