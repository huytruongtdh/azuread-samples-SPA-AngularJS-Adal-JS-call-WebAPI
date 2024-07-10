// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Crypto
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Microsoft.AspNet.Identity
{
  internal static class Crypto
  {
    private const int PBKDF2IterCount = 1000;
    private const int PBKDF2SubkeyLength = 32;
    private const int SaltSize = 16;

    public static string HashPassword(string password)
    {
      if (password == null)
        throw new ArgumentNullException(nameof (password));
      byte[] salt;
      byte[] bytes;
      using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 16, 1000))
      {
        salt = rfc2898DeriveBytes.Salt;
        bytes = rfc2898DeriveBytes.GetBytes(32);
      }
      byte[] numArray = new byte[49];
      Buffer.BlockCopy((Array) salt, 0, (Array) numArray, 1, 16);
      Buffer.BlockCopy((Array) bytes, 0, (Array) numArray, 17, 32);
      return Convert.ToBase64String(numArray);
    }

    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
      if (hashedPassword == null)
        return false;
      if (password == null)
        throw new ArgumentNullException(nameof (password));
      byte[] src = Convert.FromBase64String(hashedPassword);
      if (src.Length != 49 || src[0] != (byte) 0)
        return false;
      byte[] numArray1 = new byte[16];
      Buffer.BlockCopy((Array) src, 1, (Array) numArray1, 0, 16);
      byte[] numArray2 = new byte[32];
      Buffer.BlockCopy((Array) src, 17, (Array) numArray2, 0, 32);
      byte[] bytes;
      using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, numArray1, 1000))
        bytes = rfc2898DeriveBytes.GetBytes(32);
      return Crypto.ByteArraysEqual(numArray2, bytes);
    }

    [MethodImpl(MethodImplOptions.NoOptimization)]
    private static bool ByteArraysEqual(byte[] a, byte[] b)
    {
      if (a == b)
        return true;
      if (a == null || b == null || a.Length != b.Length)
        return false;
      bool flag = true;
      for (int index = 0; index < a.Length; ++index)
        flag &= (int) a[index] == (int) b[index];
      return flag;
    }
  }
}
