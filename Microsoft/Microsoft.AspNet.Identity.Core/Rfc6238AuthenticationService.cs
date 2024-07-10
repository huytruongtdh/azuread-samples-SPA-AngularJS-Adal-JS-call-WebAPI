// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Rfc6238AuthenticationService
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.AspNet.Identity
{
  internal static class Rfc6238AuthenticationService
  {
    private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly TimeSpan _timestep = TimeSpan.FromMinutes(3.0);
    private static readonly Encoding _encoding = (Encoding) new UTF8Encoding(false, true);

    private static int ComputeTotp(
      HashAlgorithm hashAlgorithm,
      ulong timestepNumber,
      string modifier)
    {
      byte[] bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long) timestepNumber));
      byte[] hash = hashAlgorithm.ComputeHash(Rfc6238AuthenticationService.ApplyModifier(bytes, modifier));
      int index = (int) hash[hash.Length - 1] & 15;
      return (((int) hash[index] & (int) sbyte.MaxValue) << 24 | ((int) hash[index + 1] & (int) byte.MaxValue) << 16 | ((int) hash[index + 2] & (int) byte.MaxValue) << 8 | (int) hash[index + 3] & (int) byte.MaxValue) % 1000000;
    }

    private static byte[] ApplyModifier(byte[] input, string modifier)
    {
      if (string.IsNullOrEmpty(modifier))
        return input;
      byte[] bytes = Rfc6238AuthenticationService._encoding.GetBytes(modifier);
      byte[] dst = new byte[checked (input.Length + bytes.Length)];
      Buffer.BlockCopy((Array) input, 0, (Array) dst, 0, input.Length);
      Buffer.BlockCopy((Array) bytes, 0, (Array) dst, input.Length, bytes.Length);
      return dst;
    }

    private static ulong GetCurrentTimeStepNumber() => (ulong) ((DateTime.UtcNow - Rfc6238AuthenticationService._unixEpoch).Ticks / Rfc6238AuthenticationService._timestep.Ticks);

    public static int GenerateCode(SecurityToken securityToken, string modifier = null)
    {
      if (securityToken == null)
        throw new ArgumentNullException(nameof (securityToken));
      ulong currentTimeStepNumber = Rfc6238AuthenticationService.GetCurrentTimeStepNumber();
      using (HMACSHA1 hmacshA1 = new HMACSHA1(securityToken.GetDataNoClone()))
        return Rfc6238AuthenticationService.ComputeTotp((HashAlgorithm) hmacshA1, currentTimeStepNumber, modifier);
    }

    public static bool ValidateCode(SecurityToken securityToken, int code, string modifier = null)
    {
      if (securityToken == null)
        throw new ArgumentNullException(nameof (securityToken));
      ulong currentTimeStepNumber = Rfc6238AuthenticationService.GetCurrentTimeStepNumber();
      using (HMACSHA1 hmacshA1 = new HMACSHA1(securityToken.GetDataNoClone()))
      {
        for (int index = -2; index <= 2; ++index)
        {
          if (Rfc6238AuthenticationService.ComputeTotp((HashAlgorithm) hmacshA1, currentTimeStepNumber + (ulong) index, modifier) == code)
            return true;
        }
      }
      return false;
    }
  }
}
