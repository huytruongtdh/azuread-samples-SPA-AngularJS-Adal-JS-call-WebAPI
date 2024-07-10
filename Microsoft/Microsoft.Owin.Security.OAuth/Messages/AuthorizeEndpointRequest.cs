// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Messages.AuthorizeEndpointRequest
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;
using System.Collections.Generic;

namespace Microsoft.Owin.Security.OAuth.Messages
{
  /// <summary>
  /// Data object representing the information contained in the query string of an Authorize endpoint request.
  /// </summary>
  public class AuthorizeEndpointRequest
  {
    /// <summary>
    /// Creates a new instance populated with values from the query string parameters.
    /// </summary>
    /// <param name="parameters">Query string parameters from a request.</param>
    public AuthorizeEndpointRequest(IReadableStringCollection parameters)
    {
      if (parameters == null)
        throw new ArgumentNullException(nameof (parameters));
      this.Scope = (IList<string>) new List<string>();
      foreach (KeyValuePair<string, string[]> parameter in (IEnumerable<KeyValuePair<string, string[]>>) parameters)
        this.AddParameter(parameter.Key, parameters.Get(parameter.Key));
    }

    /// <summary>
    /// The "response_type" query string parameter of the Authorize request. Known values are "code" and "token".
    /// </summary>
    public string ResponseType { get; set; }

    /// <summary>
    /// The "response_mode" query string parameter of the Authorize request. Known values are "query", "fragment" and "form_post"
    /// See also, http://openid.net/specs/oauth-v2-form-post-response-mode-1_0.html
    /// </summary>
    public string ResponseMode { get; set; }

    /// <summary>
    /// The "client_id" query string parameter of the Authorize request.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    /// The "redirect_uri" query string parameter of the Authorize request. May be absent if the server should use the
    /// redirect uri known to be registered to the client id.
    /// </summary>
    public string RedirectUri { get; set; }

    /// <summary>
    /// The "scope" query string parameter of the Authorize request. May be absent if the server should use default scopes.
    /// </summary>
    public IList<string> Scope { get; private set; }

    /// <summary>
    /// The "state" query string parameter of the Authorize request. May be absent if the client does not require state to be
    /// included when returning to the RedirectUri.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// True if the "response_type" query string parameter is "code".
    /// See also, http://tools.ietf.org/html/rfc6749#section-4.1.1
    /// </summary>
    public bool IsAuthorizationCodeGrantType => this.ContainsGrantType("code");

    /// <summary>
    /// True if the "response_type" query string parameter is "token".
    /// See also, http://tools.ietf.org/html/rfc6749#section-4.2.1
    /// </summary>
    public bool IsImplicitGrantType => this.ContainsGrantType("token");

    public bool IsFormPostResponseMode => string.Equals(this.ResponseMode, "form_post", StringComparison.Ordinal);

    /// <summary>
    /// True if the "response_type" query string contains the passed responseType.
    /// See also, http://openid.net/specs/oauth-v2-multiple-response-types-1_0.html
    /// </summary>
    /// <param name="responseType">The responseType that is expected within the "response_type" query string</param>
    /// <returns>True if the "response_type" query string contains the passed responseType.</returns>
    public bool ContainsGrantType(string responseType)
    {
      string responseType1 = this.ResponseType;
      char[] chArray = new char[1]{ ' ' };
      foreach (string a in responseType1.Split(chArray))
      {
        if (string.Equals(a, responseType, StringComparison.Ordinal))
          return true;
      }
      return false;
    }

    private void AddParameter(string name, string value)
    {
      if (string.Equals(name, "response_type", StringComparison.Ordinal))
        this.ResponseType = value;
      else if (string.Equals(name, "client_id", StringComparison.Ordinal))
        this.ClientId = value;
      else if (string.Equals(name, "redirect_uri", StringComparison.Ordinal))
        this.RedirectUri = value;
      else if (string.Equals(name, "scope", StringComparison.Ordinal))
        this.Scope = (IList<string>) value.Split(' ');
      else if (string.Equals(name, "state", StringComparison.Ordinal))
      {
        this.State = value;
      }
      else
      {
        if (!string.Equals(name, "response_mode", StringComparison.Ordinal))
          return;
        this.ResponseMode = value;
      }
    }
  }
}
