﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthGrantResourceOwnerCredentialsContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used in handling an OAuth resource owner grant.
  /// </summary>
  public class OAuthGrantResourceOwnerCredentialsContext : 
    BaseValidatingTicketContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthGrantResourceOwnerCredentialsContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="clientId"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="scope"></param>
    public OAuthGrantResourceOwnerCredentialsContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      string clientId,
      string userName,
      string password,
      IList<string> scope)
      : base(context, options, (AuthenticationTicket) null)
    {
      this.ClientId = clientId;
      this.UserName = userName;
      this.Password = password;
      this.Scope = scope;
    }

    /// <summary>OAuth client id.</summary>
    public string ClientId { get; private set; }

    /// <summary>Resource owner username.</summary>
    public string UserName { get; private set; }

    /// <summary>Resource owner password.</summary>
    public string Password { get; private set; }

    /// <summary>List of scopes allowed by the resource owner.</summary>
    public IList<string> Scope { get; private set; }
  }
}
