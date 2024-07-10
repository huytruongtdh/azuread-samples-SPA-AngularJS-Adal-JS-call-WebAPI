// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.OAuth.BaseValidatingContext`1
// Assembly: Microsoft.Owin.Security.OAuth, Version=4.2.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: E38629BB-DBA6-4112-9B8A-C8B596727323
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.Owin.Security.OAuth.xml

using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.OAuth
{
  /// <summary>Base class used for certain event contexts</summary>
  public abstract class BaseValidatingContext<TOptions> : BaseContext<TOptions>
  {
    /// <summary>
    /// Initializes base class used for certain event contexts
    /// </summary>
    protected BaseValidatingContext(IOwinContext context, TOptions options)
      : base(context, options)
    {
    }

    /// <summary>
    /// True if application code has called any of the Validate methods on this context.
    /// </summary>
    public bool IsValidated { get; private set; }

    /// <summary>
    /// True if application code has called any of the SetError methods on this context.
    /// </summary>
    public bool HasError { get; private set; }

    /// <summary>
    /// The error argument provided when SetError was called on this context. This is eventually
    /// returned to the client app as the OAuth "error" parameter.
    /// </summary>
    public string Error { get; private set; }

    /// <summary>
    /// The optional errorDescription argument provided when SetError was called on this context. This is eventually
    /// returned to the client app as the OAuth "error_description" parameter.
    /// </summary>
    public string ErrorDescription { get; private set; }

    /// <summary>
    /// The optional errorUri argument provided when SetError was called on this context. This is eventually
    /// returned to the client app as the OAuth "error_uri" parameter.
    /// </summary>
    public string ErrorUri { get; private set; }

    /// <summary>
    /// Marks this context as validated by the application. IsValidated becomes true and HasError becomes false as a result of calling.
    /// </summary>
    /// <returns>True if the validation has taken effect.</returns>
    public virtual bool Validated()
    {
      this.IsValidated = true;
      this.HasError = false;
      return true;
    }

    /// <summary>
    /// Marks this context as not validated by the application. IsValidated and HasError become false as a result of calling.
    /// </summary>
    public virtual void Rejected()
    {
      this.IsValidated = false;
      this.HasError = false;
    }

    /// <summary>
    /// Marks this context as not validated by the application and assigns various error information properties.
    /// HasError becomes true and IsValidated becomes false as a result of calling.
    /// </summary>
    /// <param name="error">Assigned to the Error property</param>
    public void SetError(string error) => this.SetError(error, (string) null);

    /// <summary>
    /// Marks this context as not validated by the application and assigns various error information properties.
    /// HasError becomes true and IsValidated becomes false as a result of calling.
    /// </summary>
    /// <param name="error">Assigned to the Error property</param>
    /// <param name="errorDescription">Assigned to the ErrorDescription property</param>
    public void SetError(string error, string errorDescription) => this.SetError(error, errorDescription, (string) null);

    /// <summary>
    /// Marks this context as not validated by the application and assigns various error information properties.
    /// HasError becomes true and IsValidated becomes false as a result of calling.
    /// </summary>
    /// <param name="error">Assigned to the Error property</param>
    /// <param name="errorDescription">Assigned to the ErrorDescription property</param>
    /// <param name="errorUri">Assigned to the ErrorUri property</param>
    public void SetError(string error, string errorDescription, string errorUri)
    {
      this.Error = error;
      this.ErrorDescription = errorDescription;
      this.ErrorUri = errorUri;
      this.Rejected();
      this.HasError = true;
    }
  }
}
