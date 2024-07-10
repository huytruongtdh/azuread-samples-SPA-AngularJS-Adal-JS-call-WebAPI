// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider`1
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.Owin.Security.DataProtection;

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>
  ///     Token provider that uses an IDataProtector to generate encrypted tokens based off of the security stamp
  /// </summary>
  public class DataProtectorTokenProvider<TUser> : DataProtectorTokenProvider<TUser, string> where TUser : class, IUser<string>
  {
    /// <summary>Constructor</summary>
    /// <param name="protector"></param>
    public DataProtectorTokenProvider(IDataProtector protector)
      : base(protector)
    {
    }
  }
}
