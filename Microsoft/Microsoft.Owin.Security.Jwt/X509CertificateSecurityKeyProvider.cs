// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.X509CertificateSecurityKeyProvider
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Owin.Security.Jwt
{
  /// <summary>
  /// Implements an <see cref="T:Microsoft.Owin.Security.Jwt.IIssuerSecurityKeyProvider" /> for X509 JWTs.
  /// </summary>
  public class X509CertificateSecurityKeyProvider : IIssuerSecurityKeyProvider
  {
    private readonly List<SecurityKey> _keys = new List<SecurityKey>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.X509CertificateSecurityKeyProvider" /> class.
    /// </summary>
    /// <param name="issuer">The issuer.</param>
    /// <param name="certificate">The certificate.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// issuer
    /// or
    /// certificate
    /// </exception>
    public X509CertificateSecurityKeyProvider(string issuer, X509Certificate2 certificate)
    {
      if (string.IsNullOrWhiteSpace(issuer))
        throw new ArgumentNullException(nameof (issuer));
      if (certificate == null)
        throw new ArgumentNullException(nameof (certificate));
      this.Issuer = issuer;
      this._keys.Add((SecurityKey) new X509SecurityKey(certificate));
    }

    /// <summary>Gets the issuer the credentials are for.</summary>
    /// <value>The issuer the credentials are for.</value>
    public string Issuer { get; private set; }

    /// <summary>Gets all known security keys.</summary>
    /// <value>All known security keys.</value>
    public IEnumerable<SecurityKey> SecurityKeys => (IEnumerable<SecurityKey>) this._keys.AsReadOnly();
  }
}
