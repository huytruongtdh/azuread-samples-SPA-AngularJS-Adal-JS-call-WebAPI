// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthValidateIdentityContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Contains the authentication ticket data from an OAuth bearer token.
  /// </summary>
  public class OAuthValidateIdentityContext : 
    BaseValidatingTicketContext<OAuthBearerAuthenticationOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthValidateIdentityContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="ticket"></param>
    public OAuthValidateIdentityContext(
      IOwinContext context,
      OAuthBearerAuthenticationOptions options,
      AuthenticationTicket ticket)
      : base(context, options, ticket)
    {
    }
  }
}
