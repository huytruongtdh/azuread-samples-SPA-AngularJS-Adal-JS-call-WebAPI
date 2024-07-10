// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.OAuthValidateClientAuthenticationContext
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;
using System.Text;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>Contains information about the client credentials.</summary>
  public class OAuthValidateClientAuthenticationContext : BaseValidatingClientContext
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Owin.Security.OAuth.OAuthValidateClientAuthenticationContext" /> class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="parameters"></param>
    public OAuthValidateClientAuthenticationContext(
      IOwinContext context,
      OAuthAuthorizationServerOptions options,
      IReadableStringCollection parameters)
      : base(context, options, (string) null)
    {
      this.Parameters = parameters;
    }

    /// <summary>Gets the set of form parameters from the request.</summary>
    public IReadableStringCollection Parameters { get; private set; }

    /// <summary>
    /// Sets the client id and marks the context as validated by the application.
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    public bool Validated(string clientId)
    {
      this.ClientId = clientId;
      return this.Validated();
    }

    /// <summary>
    /// Extracts HTTP basic authentication credentials from the HTTP authenticate header.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <returns></returns>
    public bool TryGetBasicCredentials(out string clientId, out string clientSecret)
    {
      string str1 = this.Request.Headers.Get("Authorization");
      if (!string.IsNullOrWhiteSpace(str1))
      {
        if (str1.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
          try
          {
            string str2 = Encoding.UTF8.GetString(Convert.FromBase64String(str1.Substring("Basic ".Length).Trim()));
            int length = str2.IndexOf(':');
            if (length >= 0)
            {
              clientId = str2.Substring(0, length);
              clientSecret = str2.Substring(length + 1);
              this.ClientId = clientId;
              return true;
            }
          }
          catch (FormatException ex)
          {
          }
          catch (ArgumentException ex)
          {
          }
        }
      }
      clientId = (string) null;
      clientSecret = (string) null;
      return false;
    }

    /// <summary>
    /// Extracts forms authentication credentials from the HTTP request body.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <returns></returns>
    public bool TryGetFormCredentials(out string clientId, out string clientSecret)
    {
      clientId = this.Parameters.Get("client_id");
      if (!string.IsNullOrEmpty(clientId))
      {
        clientSecret = this.Parameters.Get("client_secret");
        this.ClientId = clientId;
        return true;
      }
      clientId = (string) null;
      clientSecret = (string) null;
      return false;
    }
  }
}
