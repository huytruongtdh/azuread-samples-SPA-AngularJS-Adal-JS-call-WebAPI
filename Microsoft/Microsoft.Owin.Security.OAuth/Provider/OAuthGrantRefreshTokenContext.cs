// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthGrantRefreshTokenContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used when granting an OAuth refresh token.
  /// </summary>
  public class OAuthGrantRefreshTokenContext : 
    BaseValidatingTicketContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthGrantRefreshTokenContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="ticket"></param>
    /// <param name="clientId"></param>
    public OAuthGrantRefreshTokenContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      AuthenticationTicket ticket,
      string clientId)
      : base(context, options, ticket)
    {
      this.ClientId = clientId;
    }

    /// <summary>The OAuth client id.</summary>
    public string ClientId { get; private set; }
  }
}
