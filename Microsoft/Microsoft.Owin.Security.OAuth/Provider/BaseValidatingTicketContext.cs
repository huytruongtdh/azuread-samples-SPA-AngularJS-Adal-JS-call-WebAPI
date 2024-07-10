// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.BaseValidatingTicketContext`1
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using System.Security.Claims;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>Base class used for certain event contexts</summary>
  public abstract class BaseValidatingTicketContext<TOptions> : BaseValidatingContext<TOptions>
  {
    /// <summary>
    /// Initializes base class used for certain event contexts
    /// </summary>
    protected BaseValidatingTicketContext(
      IOwinContext context,
      TOptions options,
      AuthenticationTicket ticket)
      : base(context, options)
    {
      this.Ticket = ticket;
    }

    /// <summary>
    /// Contains the identity and properties for the application to authenticate. If the Validated method
    /// is invoked with an AuthenticationTicket or ClaimsIdentity argument, that new value is assigned to
    /// this property in addition to changing IsValidated to true.
    /// </summary>
    public AuthenticationTicket Ticket { get; private set; }

    /// <summary>
    /// Replaces the ticket information on this context and marks it as as validated by the application.
    /// IsValidated becomes true and HasError becomes false as a result of calling.
    /// </summary>
    /// <param name="ticket">Assigned to the Ticket property</param>
    /// <returns>True if the validation has taken effect.</returns>
    public bool Validated(AuthenticationTicket ticket)
    {
      this.Ticket = ticket;
      return this.Validated();
    }

    /// <summary>
    /// Alters the ticket information on this context and marks it as as validated by the application.
    /// IsValidated becomes true and HasError becomes false as a result of calling.
    /// </summary>
    /// <param name="identity">Assigned to the Ticket.Identity property</param>
    /// <returns>True if the validation has taken effect.</returns>
    public bool Validated(ClaimsIdentity identity)
    {
      AuthenticationProperties properties = this.Ticket != null ? this.Ticket.Properties : new AuthenticationProperties();
      return this.Validated(new AuthenticationTicket(identity, properties));
    }
  }
}
