// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions
// Assembly: Microsoft.Owin.Security.Google, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: ABA4976A-D7B6-4EDF-A8C7-0435456180C4
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.Google.xml

using Microsoft.Owin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Owin.Security.Google
{
    /// <summary>
    /// Configuration options for <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationMiddleware" />
    /// </summary>
    public class GoogleOAuth2AuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationOptions" />
        /// </summary>
        public GoogleOAuth2AuthenticationOptions()
          : base("Google")
        {
            this.Caption = "Google";
            this.CallbackPath = new PathString("/signin-google");
            this.AuthenticationMode = AuthenticationMode.Passive;
            this.Scope = (IList<string>)new List<string>();
            this.BackchannelTimeout = TimeSpan.FromSeconds(60.0);
            this.CookieManager = (ICookieManager)new Microsoft.Owin.Infrastructure.CookieManager();
            this.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
            this.TokenEndpoint = "https://oauth2.googleapis.com/token";
            this.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
        }

        /// <summary>Gets or sets the Google-assigned client id</summary>
        public string ClientId { get; set; }

        /// <summary>Gets or sets the Google-assigned client secret</summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the URI where the client will be redirected to authenticate.
        /// </summary>
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the URI the middleware will access to exchange the OAuth token.
        /// </summary>
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the URI the middleware will access to obtain the user information.
        /// </summary>
        public string UserInformationEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the a pinned certificate validator to use to validate the endpoints used
        /// in back channel communications belong to Google.
        /// </summary>
        /// <value>The pinned certificate validator.</value>
        /// <remarks>If this property is null then the default certificate checks are performed,
        /// validating the subject name and if the signing chain is a trusted party.</remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with Google.
        /// </summary>
        /// <value>The back channel timeout in milliseconds.</value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to communicate with Google.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value
        /// can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get => this.Description.Caption;
            set => this.Description.Caption = value;
        }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin-google".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user <see cref="T:System.Security.Claims.ClaimsIdentity" />.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.Owin.Security.Google.IGoogleOAuth2AuthenticationProvider" /> used to handle authentication events.
        /// </summary>
        public IGoogleOAuth2AuthenticationProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        /// <summary>A list of permissions to request.</summary>
        public IList<string> Scope { get; private set; }

        /// <summary>
        /// access_type. Set to 'offline' to request a refresh token.
        /// </summary>
        public string AccessType { get; set; }

        /// <summary>
        /// An abstraction for reading and setting cookies during the authentication process.
        /// </summary>
        public ICookieManager CookieManager { get; set; }
    }
}
