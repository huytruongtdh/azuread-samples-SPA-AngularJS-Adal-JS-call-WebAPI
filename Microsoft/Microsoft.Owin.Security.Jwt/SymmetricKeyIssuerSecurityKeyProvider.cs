// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Jwt.SymmetricKeyIssuerSecurityKeyProvider
// Assembly: Microsoft.Owin.Security.Jwt, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 4310466D-5A64-4ACC-B51D-5143202ABD27
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Jwt.xml

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace Microsoft.Owin.Security.Jwt
{
  /// <summary>
  /// Implements an <see cref="T:Microsoft.Owin.Security.Jwt.IIssuerSecurityKeyProvider" /> for symmetric key signed JWTs.
  /// </summary>
  public class SymmetricKeyIssuerSecurityKeyProvider : IIssuerSecurityKeyProvider
  {
    private readonly List<SecurityKey> _keys = new List<SecurityKey>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.SymmetricKeyIssuerSecurityKeyProvider" /> class.
    /// </summary>
    /// <param name="issuer">The issuer of a JWT token.</param>
    /// <param name="key">The symmetric key a JWT is signed with.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown when the issuer is null.</exception>
    public SymmetricKeyIssuerSecurityKeyProvider(string issuer, byte[] key)
      : this(issuer, (IEnumerable<byte[]>) new byte[1][]
      {
        key
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.SymmetricKeyIssuerSecurityKeyProvider" /> class.
    /// </summary>
    /// <param name="issuer">The issuer of a JWT token.</param>
    /// <param name="keys">Symmetric keys a JWT could be signed with.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown when the issuer is null.</exception>
    public SymmetricKeyIssuerSecurityKeyProvider(string issuer, IEnumerable<byte[]> keys)
    {
      if (string.IsNullOrWhiteSpace(issuer))
        throw new ArgumentNullException(nameof (issuer));
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      this.Issuer = issuer;
      foreach (byte[] key in keys)
        this._keys.Add((SecurityKey) new SymmetricSecurityKey(key));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.SymmetricKeyIssuerSecurityKeyProvider" /> class.
    /// </summary>
    /// <param name="issuer">The issuer of a JWT token.</param>
    /// <param name="base64Key">The base64 encoded symmetric key a JWT is signed with.</param>
    /// <exception cref="T:System.ArgumentNullException">Thrown when the issuer is null.</exception>
    public SymmetricKeyIssuerSecurityKeyProvider(string issuer, string base64Key)
      : this(issuer, (IEnumerable<string>) new string[1]
      {
        base64Key
      })
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.Jwt.SymmetricKeyIssuerSecurityKeyProvider" /> class.
    /// </summary>
    /// <param name="issuer">The issuer of a JWT token.</param>
    /// <param name="base64Keys">The base64 encoded symmetric keys a JWT could be signed with.</param>
    public SymmetricKeyIssuerSecurityKeyProvider(string issuer, IEnumerable<string> base64Keys)
    {
      if (string.IsNullOrWhiteSpace(issuer))
        throw new ArgumentNullException(nameof (issuer));
      if (base64Keys == null)
        throw new ArgumentNullException(nameof (base64Keys));
      this.Issuer = issuer;
      foreach (string base64Key in base64Keys)
        this._keys.Add((SecurityKey) new SymmetricSecurityKey(Convert.FromBase64String(base64Key)));
    }

    /// <summary>Gets the issuer the signing keys are for.</summary>
    /// <value>The issuer the signing keys are for.</value>
    public string Issuer { get; private set; }

    /// <summary>Gets all known security keys.</summary>
    /// <returns>All known security keys.</returns>
    public IEnumerable<SecurityKey> SecurityKeys => (IEnumerable<SecurityKey>) this._keys.AsReadOnly();
  }
}
