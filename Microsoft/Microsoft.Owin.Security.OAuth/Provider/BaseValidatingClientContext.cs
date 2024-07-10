// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.BaseValidatingClientContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>Base class used for certain event contexts</summary>
  public abstract class BaseValidatingClientContext : 
    BaseValidatingContext<OAuthAuthorizationServerOptions>
  {
    /// <summary>
    /// Initializes base class used for certain event contexts
    /// </summary>
    protected BaseValidatingClientContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      string clientId)
      : base(context, options)
    {
      this.ClientId = clientId;
    }

    /// <summary>
    /// The "client_id" parameter for the current request. The Authorization Server application is responsible for
    /// validating this value identifies a registered client.
    /// </summary>
    public string ClientId { get; protected set; }
  }
}
