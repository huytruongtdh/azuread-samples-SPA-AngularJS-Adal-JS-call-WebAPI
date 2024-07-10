// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.GoogleOAuth2ReturnEndpointContext
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Google
{
  /// <summary>Provides context information to middleware providers.</summary>
  public class GoogleOAuth2ReturnEndpointContext : ReturnEndpointContext
  {
    /// <summary>
    /// Initialize a <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2ReturnEndpointContext" />
    /// </summary>
    /// <param name="context">OWIN environment</param>
    /// <param name="ticket">The authentication ticket</param>
    public GoogleOAuth2ReturnEndpointContext(IOwinContext context, AuthenticationTicket ticket)
      : base(context, ticket)
    {
    }
  }
}
