// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthGrantCustomExtensionContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>
  /// Provides context information used when handling OAuth extension grant types.
  /// </summary>
  public class OAuthGrantCustomExtensionContext : 
    BaseValidatingTicketContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthGrantCustomExtensionContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="clientId"></param>
    /// <param name="grantType"></param>
    /// <param name="parameters"></param>
    public OAuthGrantCustomExtensionContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      string clientId,
      string grantType,
      IReadableStringCollection parameters)
      : base(context, options, (AuthenticationTicket) null)
    {
      this.ClientId = clientId;
      this.GrantType = grantType;
      this.Parameters = parameters;
    }

    /// <summary>Gets the OAuth client id.</summary>
    public string ClientId { get; private set; }

    /// <summary>Gets the name of the OAuth extension grant type.</summary>
    public string GrantType { get; private set; }

    /// <summary>
    /// Gets a list of additional parameters from the token request.
    /// </summary>
    public IReadableStringCollection Parameters { get; private set; }
  }
}
