// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.PasswordHasher
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

namespace Microsoft.AspNet.Identity
{
  /// <summary>Implements password hashing methods</summary>
  public class PasswordHasher : IPasswordHasher
  {
    /// <summary>Hash a password</summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual string HashPassword(string password) => Crypto.HashPassword(password);

    /// <summary>Verify that a password matches the hashedPassword</summary>
    /// <param name="hashedPassword"></param>
    /// <param name="providedPassword"></param>
    /// <returns></returns>
    public virtual PasswordVerificationResult VerifyHashedPassword(
      string hashedPassword,
      string providedPassword)
    {
      return Crypto.VerifyHashedPassword(hashedPassword, providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }
  }
}
