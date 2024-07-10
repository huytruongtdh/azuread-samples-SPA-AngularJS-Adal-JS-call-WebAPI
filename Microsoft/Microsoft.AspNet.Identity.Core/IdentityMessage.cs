// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IdentityMessage
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Represents a message</summary>
  public class IdentityMessage
  {
    /// <summary>Destination, i.e. To email, or SMS phone number</summary>
    public virtual string Destination { get; set; }

    /// <summary>Subject</summary>
    public virtual string Subject { get; set; }

    /// <summary>Message contents</summary>
    public virtual string Body { get; set; }
  }
}
