// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.IIssuerSecurityKeyProvider
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Microsoft.Owin.Security.Jwt
{
  /// <summary>
  /// Provides security key information to the implementing class.
  /// </summary>
  public interface IIssuerSecurityKeyProvider
  {
    /// <summary>Gets the issuer the credentials are for.</summary>
    /// <value>The issuer the credentials are for.</value>
    string Issuer { get; }

    /// <summary>Gets all known security keys.</summary>
    /// <value>All known security keys.</value>
    IEnumerable<SecurityKey> SecurityKeys { get; }
  }
}
