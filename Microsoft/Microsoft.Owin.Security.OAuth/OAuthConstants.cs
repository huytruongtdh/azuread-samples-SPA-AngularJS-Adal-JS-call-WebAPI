﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.Constants
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

namespace Microsoft.Owin.Security.OAuth
{
  internal static class Constants
  {
    public static class Parameters
    {
      public const string ResponseType = "response_type";
      public const string GrantType = "grant_type";
      public const string ClientId = "client_id";
      public const string ClientSecret = "client_secret";
      public const string RedirectUri = "redirect_uri";
      public const string Scope = "scope";
      public const string State = "state";
      public const string Code = "code";
      public const string RefreshToken = "refresh_token";
      public const string Username = "username";
      public const string Password = "password";
      public const string Error = "error";
      public const string ErrorDescription = "error_description";
      public const string ErrorUri = "error_uri";
      public const string ExpiresIn = "expires_in";
      public const string AccessToken = "access_token";
      public const string TokenType = "token_type";
      public const string ResponseMode = "response_mode";
    }

    public static class ResponseTypes
    {
      public const string Code = "code";
      public const string Token = "token";
    }

    public static class GrantTypes
    {
      public const string AuthorizationCode = "authorization_code";
      public const string ClientCredentials = "client_credentials";
      public const string RefreshToken = "refresh_token";
      public const string Password = "password";
    }

    public static class TokenTypes
    {
      public const string Bearer = "bearer";
    }

    public static class Errors
    {
      public const string InvalidRequest = "invalid_request";
      public const string InvalidClient = "invalid_client";
      public const string InvalidGrant = "invalid_grant";
      public const string UnsupportedResponseType = "unsupported_response_type";
      public const string UnsupportedGrantType = "unsupported_grant_type";
      public const string UnauthorizedClient = "unauthorized_client";
    }

    public static class Extra
    {
      public const string ClientId = "client_id";
      public const string RedirectUri = "redirect_uri";
    }

    public static class ResponseModes
    {
      public const string FormPost = "form_post";
    }
  }
}
