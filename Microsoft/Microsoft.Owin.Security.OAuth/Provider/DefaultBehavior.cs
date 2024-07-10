// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.DefaultBehavior
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.OAuth
{
  internal static class DefaultBehavior
  {
    internal static readonly Func<OAuthValidateAuthorizeRequestContext, Task> ValidateAuthorizeRequest = (Func<OAuthValidateAuthorizeRequestContext, Task>) (context =>
    {
      context.Validated();
      return (Task) Task.FromResult<object>((object) null);
    });
    internal static readonly Func<OAuthValidateTokenRequestContext, Task> ValidateTokenRequest = (Func<OAuthValidateTokenRequestContext, Task>) (context =>
    {
      context.Validated();
      return (Task) Task.FromResult<object>((object) null);
    });
    internal static readonly Func<OAuthGrantAuthorizationCodeContext, Task> GrantAuthorizationCode = (Func<OAuthGrantAuthorizationCodeContext, Task>) (context =>
    {
      if (context.Ticket != null && context.Ticket.Identity != null && context.Ticket.Identity.IsAuthenticated)
        context.Validated();
      return (Task) Task.FromResult<object>((object) null);
    });
    internal static readonly Func<OAuthGrantRefreshTokenContext, Task> GrantRefreshToken = (Func<OAuthGrantRefreshTokenContext, Task>) (context =>
    {
      if (context.Ticket != null && context.Ticket.Identity != null && context.Ticket.Identity.IsAuthenticated)
        context.Validated();
      return (Task) Task.FromResult<object>((object) null);
    });
  }
}
