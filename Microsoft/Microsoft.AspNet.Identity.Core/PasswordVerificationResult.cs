// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.PasswordVerificationResult
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Return result for IPasswordHasher</summary>
  public enum PasswordVerificationResult
  {
    /// <summary>Password verification failed</summary>
    Failed,
    /// <summary>Success</summary>
    Success,
    /// <summary>Success but should update and rehash the password</summary>
    SuccessRehashNeeded,
  }
}
