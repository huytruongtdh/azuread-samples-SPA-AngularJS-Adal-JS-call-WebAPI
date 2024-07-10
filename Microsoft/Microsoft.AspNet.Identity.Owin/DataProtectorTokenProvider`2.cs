// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider`2
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin.Security.DataProtection;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Token provider that uses an IDataProtector to generate encrypted tokens based off of the security stamp
  /// </summary>
  public class DataProtectorTokenProvider<TUser, TKey> : IUserTokenProvider<TUser, TKey>
    where TUser : class, IUser<TKey>
    where TKey : IEquatable<TKey>
  {
    /// <summary>Constructor</summary>
    /// <param name="protector"></param>
    public DataProtectorTokenProvider(IDataProtector protector)
    {
      this.Protector = protector != null ? protector : throw new ArgumentNullException(nameof (protector));
      this.TokenLifespan = TimeSpan.FromDays(1.0);
    }

    /// <summary>IDataProtector for the token</summary>
    public IDataProtector Protector { get; private set; }

    /// <summary>
    ///     Lifespan after which the token is considered expired
    /// </summary>
    public TimeSpan TokenLifespan { get; set; }

    public async Task<string> GenerateAsync(
      string purpose,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      if ((object) user == null)
        throw new ArgumentNullException(nameof (user));
      MemoryStream ms = new MemoryStream();
      using (BinaryWriter writer = ms.CreateWriter())
      {
        writer.Write(DateTimeOffset.UtcNow);
        writer.Write(Convert.ToString((object) ((IUser<TKey>) (object) user).Id, (IFormatProvider) CultureInfo.InvariantCulture));
        writer.Write(purpose ?? "");
        string str = (string) null;
        if (manager.SupportsUserSecurityStamp)
          str = await TaskExtensions.WithCurrentCulture<string>(manager.GetSecurityStampAsync(((IUser<TKey>) (object) user).Id));
        writer.Write(str ?? "");
      }
      return Convert.ToBase64String(this.Protector.Protect(ms.ToArray()));
    }

    public async Task<bool> ValidateAsync(
      string purpose,
      string token,
      UserManager<TUser, TKey> manager,
      TUser user)
    {
      try
      {
        using (BinaryReader reader = new MemoryStream(this.Protector.Unprotect(Convert.FromBase64String(token))).CreateReader())
        {
          if (reader.ReadDateTimeOffset() + this.TokenLifespan < DateTimeOffset.UtcNow || !string.Equals(reader.ReadString(), Convert.ToString((object) ((IUser<TKey>) (object) user).Id, (IFormatProvider) CultureInfo.InvariantCulture)) || !string.Equals(reader.ReadString(), purpose))
            return false;
          string stamp = reader.ReadString();
          if (reader.PeekChar() != -1)
            return false;
          return manager.SupportsUserSecurityStamp ? stamp == await TaskExtensions.WithCurrentCulture<string>(manager.GetSecurityStampAsync(((IUser<TKey>) (object) user).Id)) : stamp == "";
        }
      }
      catch
      {
      }
      return false;
    }

    public Task<bool> IsValidProviderForUserAsync(UserManager<TUser, TKey> manager, TUser user) => Task.FromResult<bool>(true);

    public Task NotifyAsync(string token, UserManager<TUser, TKey> manager, TUser user) => (Task) Task.FromResult<int>(0);
  }
}
