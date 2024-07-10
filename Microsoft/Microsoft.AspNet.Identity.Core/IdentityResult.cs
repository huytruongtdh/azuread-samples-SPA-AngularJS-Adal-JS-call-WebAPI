// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.IdentityResult
// Assembly: Microsoft.AspNet.Identity.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 1F697140-EC90-4E91-9515-466B85FE6F37
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Core.xml

using System.Collections.Generic;

namespace Microsoft.AspNet.Identity
{
  /// <summary>Represents the result of an identity operation</summary>
  public class IdentityResult
  {
    private static readonly IdentityResult _success = new IdentityResult(true);

    /// <summary>Failure constructor that takes error messages</summary>
    /// <param name="errors"></param>
    public IdentityResult(params string[] errors)
      : this((IEnumerable<string>) errors)
    {
    }

    /// <summary>Failure constructor that takes error messages</summary>
    /// <param name="errors"></param>
    public IdentityResult(IEnumerable<string> errors)
    {
      if (errors == null)
        errors = (IEnumerable<string>) new string[1]
        {
          Resources.DefaultError
        };
      this.Succeeded = false;
      this.Errors = errors;
    }

    /// <summary>Constructor that takes whether the result is successful</summary>
    /// <param name="success"></param>
    protected IdentityResult(bool success)
    {
      this.Succeeded = success;
      this.Errors = (IEnumerable<string>) new string[0];
    }

    /// <summary>True if the operation was successful</summary>
    public bool Succeeded { get; private set; }

    /// <summary>List of errors</summary>
    public IEnumerable<string> Errors { get; private set; }

    /// <summary>Static success result</summary>
    /// <returns></returns>
    public static IdentityResult Success => IdentityResult._success;

    /// <summary>Failed helper method</summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static IdentityResult Failed(params string[] errors) => new IdentityResult(errors);
  }
}
