// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticatedContext
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Security.Claims;

namespace Microsoft.Owin.Security.Google
{
  /// <summary>
  /// Contains information about the login session as well as the user <see cref="T:System.Security.Claims.ClaimsIdentity" />.
  /// </summary>
  public class GoogleOAuth2AuthenticatedContext : BaseContext
  {
    /// <summary>
    /// Initializes a <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticatedContext" />
    /// </summary>
    /// <param name="context">The OWIN environment</param>
    /// <param name="user">The JSON-serialized Google user info</param>
    /// <param name="accessToken">Google OAuth 2.0 access token</param>
    /// <param name="refreshToken">Goolge OAuth 2.0 refresh token</param>
    /// <param name="expires">Seconds until expiration</param>
    public GoogleOAuth2AuthenticatedContext(
      IOwinContext context,
      JObject user,
      string accessToken,
      string refreshToken,
      string expires)
      : base(context)
    {
      this.User = user;
      this.AccessToken = accessToken;
      this.RefreshToken = refreshToken;
      int result;
      if (int.TryParse(expires, NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        this.ExpiresIn = new TimeSpan?(TimeSpan.FromSeconds((double) result));
      this.Id = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "id");
      this.Name = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "name");
      this.GivenName = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "given_name");
      this.FamilyName = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "family_name");
      this.Profile = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "link");
      this.Email = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "email");
    }

    /// <summary>
    /// Initializes a <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticatedContext" />
    /// </summary>
    /// <param name="context">The OWIN environment</param>
    /// <param name="user">The JSON-serialized Google user info</param>
    /// <param name="tokenResponse">The JSON-serialized token response Google</param>
    public GoogleOAuth2AuthenticatedContext(
      IOwinContext context,
      JObject user,
      JObject tokenResponse)
      : base(context)
    {
      this.User = user;
      this.TokenResponse = tokenResponse;
      if (tokenResponse != null)
      {
        this.AccessToken = ((JToken) tokenResponse).Value<string>((object) "access_token");
        this.RefreshToken = ((JToken) tokenResponse).Value<string>((object) "refresh_token");
        int result;
        if (int.TryParse(((JToken) tokenResponse).Value<string>((object) "expires_in"), NumberStyles.Integer, (IFormatProvider) CultureInfo.InvariantCulture, out result))
          this.ExpiresIn = new TimeSpan?(TimeSpan.FromSeconds((double) result));
      }
      this.Id = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "id");
      this.Name = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "name");
      this.GivenName = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "given_name");
      this.FamilyName = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "family_name");
      this.Profile = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "link");
      this.Email = GoogleOAuth2AuthenticatedContext.TryGetValue(user, "email");
    }

    /// <summary>Gets the JSON-serialized user</summary>
    /// <remarks>
    /// Contains the Google user obtained from the UserInformationEndpoint
    /// </remarks>
    public JObject User { get; private set; }

    /// <summary>Gets the Google access token</summary>
    public string AccessToken { get; private set; }

    /// <summary>Gets the Google refresh token</summary>
    /// <remarks>
    /// This value is not null only when access_type authorize parameter is offline.
    /// </remarks>
    public string RefreshToken { get; private set; }

    /// <summary>Gets the Google access token expiration time</summary>
    public TimeSpan? ExpiresIn { get; set; }

    /// <summary>Gets the Google user ID</summary>
    public string Id { get; private set; }

    /// <summary>Gets the user's name</summary>
    public string Name { get; private set; }

    /// <summary>Gets the user's given name</summary>
    public string GivenName { get; set; }

    /// <summary>Gets the user's family name</summary>
    public string FamilyName { get; set; }

    /// <summary>Gets the user's profile link</summary>
    public string Profile { get; private set; }

    /// <summary>Gets the user's email</summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets the <see cref="T:System.Security.Claims.ClaimsIdentity" /> representing the user
    /// </summary>
    public ClaimsIdentity Identity { get; set; }

    /// <summary>Token response from Google</summary>
    public JObject TokenResponse { get; private set; }

    /// <summary>
    /// Gets or sets a property bag for common authentication properties
    /// </summary>
    public AuthenticationProperties Properties { get; set; }

    private static string TryGetValue(JObject user, string propertyName)
    {
      JToken jtoken;
      return !user.TryGetValue(propertyName, out jtoken) ? (string) null : ((object) jtoken).ToString();
    }
  }
}
