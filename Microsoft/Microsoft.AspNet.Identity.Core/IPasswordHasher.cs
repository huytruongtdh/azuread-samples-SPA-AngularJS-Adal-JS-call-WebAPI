// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IPasswordHasher
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Abstraction for password hashing methods</summary>
  public interface IPasswordHasher
  {
    /// <summary>Hash a password</summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string HashPassword(string password);

    /// <summary>Verify that a password matches the hashed password</summary>
    /// <param name="hashedPassword"></param>
    /// <param name="providedPassword"></param>
    /// <returns></returns>
    PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
  }
}
