// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.SignInStatus
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

namespace Microsoft.AspNet.Identity.Owin
{
  /// <summary>Possible results from a sign in attempt</summary>
  public enum SignInStatus
  {
    /// <summary>Sign in was successful</summary>
    Success,
    /// <summary>User is locked out</summary>
    LockedOut,
    /// <summary>
    /// Sign in requires addition verification (i.e. two factor)
    /// </summary>
    RequiresVerification,
    /// <summary>Sign in failed</summary>
    Failure,
  }
}
