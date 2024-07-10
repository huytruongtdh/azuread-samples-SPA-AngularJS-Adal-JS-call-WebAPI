// Decompiled with JetBrains decompiler
// Type: Owin.AppBuilderExtensions
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
//using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Owin
{
    //
    // Summary:
    //     Extensions off of IAppBuilder to make it easier to configure the SignInCookies
    public static class AppBuilderExtensions
    {
        private class ApplicationOAuthBearerProvider : OAuthBearerAuthenticationProvider
        {
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                if (context.Ticket.Identity.Claims.Any((Claim c) => c.Issuer != "LOCAL AUTHORITY"))
                {
                    context.Rejected();
                }

                return Task.FromResult<object>(null);
            }
        }

        private class ExternalOAuthBearerProvider : OAuthBearerAuthenticationProvider
        {
            public override Task ValidateIdentity(OAuthValidateIdentityContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                if (context.Ticket.Identity.Claims.Count() == 0)
                {
                    context.Rejected();
                }
                else if (context.Ticket.Identity.Claims.All((Claim c) => c.Issuer == "LOCAL AUTHORITY"))
                {
                    context.Rejected();
                }

                return Task.FromResult<object>(null);
            }
        }

        private const string CookiePrefix = ".AspNet.";

        //
        // Summary:
        //     Registers a callback that will be invoked to create an instance of type T that
        //     will be stored in the OwinContext which can fetched via context.Get
        //
        // Parameters:
        //   app:
        //     The Owin.IAppBuilder passed to the configuration method
        //
        //   createCallback:
        //     Invoked to create an instance of T
        //
        // Type parameters:
        //   T:
        //
        // Returns:
        //     The updated Owin.IAppBuilder
        public static IAppBuilder CreatePerOwinContext<T>(this IAppBuilder app, Func<T> createCallback) where T : class, IDisposable
        {
            return app.CreatePerOwinContext((IdentityFactoryOptions<T> options, IOwinContext context) => createCallback());
        }

        //
        // Summary:
        //     Registers a callback that will be invoked to create an instance of type T that
        //     will be stored in the OwinContext which can fetched via context.Get
        //
        // Parameters:
        //   app:
        //
        //   createCallback:
        //
        // Type parameters:
        //   T:
        public static IAppBuilder CreatePerOwinContext<T>(this IAppBuilder app, Func<IdentityFactoryOptions<T>, IOwinContext, T> createCallback) where T : class, IDisposable
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            return app.CreatePerOwinContext(createCallback, delegate (IdentityFactoryOptions<T> options, T instance)
            {
                instance.Dispose();
            });
        }

        //
        // Summary:
        //     Registers a callback that will be invoked to create an instance of type T that
        //     will be stored in the OwinContext which can fetched via context.Get
        //
        // Parameters:
        //   app:
        //
        //   createCallback:
        //
        //   disposeCallback:
        //
        // Type parameters:
        //   T:
        public static IAppBuilder CreatePerOwinContext<T>(this IAppBuilder app, Func<IdentityFactoryOptions<T>, IOwinContext, T> createCallback, Action<IdentityFactoryOptions<T>, T> disposeCallback) where T : class, IDisposable
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            if (createCallback == null)
            {
                throw new ArgumentNullException("createCallback");
            }

            if (disposeCallback == null)
            {
                throw new ArgumentNullException("disposeCallback");
            }

            app.Use(typeof(IdentityFactoryMiddleware<T, IdentityFactoryOptions<T>>), new IdentityFactoryOptions<T>
            {
                DataProtectionProvider = app.GetDataProtectionProvider(),
                Provider = new IdentityFactoryProvider<T>
                {
                    OnCreate = createCallback,
                    OnDispose = disposeCallback
                }
            });
            return app;
        }

        //
        // Summary:
        //     Configure the app to use owin middleware based cookie authentication for external
        //     identities
        //
        // Parameters:
        //   app:
        public static void UseExternalSignInCookie(this IAppBuilder app)
        {
            app.UseExternalSignInCookie("ExternalCookie");
        }

        //
        // Summary:
        //     Configure the app to use owin middleware based cookie authentication for external
        //     identities
        //
        // Parameters:
        //   app:
        //
        //   externalAuthenticationType:
        public static void UseExternalSignInCookie(this IAppBuilder app, string externalAuthenticationType)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.SetDefaultSignInAsAuthenticationType(externalAuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = externalAuthenticationType,
                AuthenticationMode = AuthenticationMode.Passive,
                CookieName = ".AspNet." + externalAuthenticationType,
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0)
            });
        }

        //
        // Summary:
        //     Configures a cookie intended to be used to store the partial credentials for
        //     two factor authentication
        //
        // Parameters:
        //   app:
        //
        //   authenticationType:
        //
        //   expires:
        public static void UseTwoFactorSignInCookie(this IAppBuilder app, string authenticationType, TimeSpan expires)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = authenticationType,
                AuthenticationMode = AuthenticationMode.Passive,
                CookieName = ".AspNet." + authenticationType,
                ExpireTimeSpan = expires
            });
        }

        //
        // Summary:
        //     Configures a cookie intended to be used to store whether two factor authentication
        //     has been done already
        //
        // Parameters:
        //   app:
        //
        //   authenticationType:
        public static void UseTwoFactorRememberBrowserCookie(this IAppBuilder app, string authenticationType)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = authenticationType,
                AuthenticationMode = AuthenticationMode.Passive,
                CookieName = ".AspNet." + authenticationType
            });
        }

        //
        // Summary:
        //     Configure the app to use owin middleware based oauth bearer tokens
        //
        // Parameters:
        //   app:
        //
        //   options:
        public static void UseOAuthBearerTokens(this IAppBuilder app, OAuthAuthorizationServerOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = options.AccessTokenFormat,
                AccessTokenProvider = options.AccessTokenProvider,
                AuthenticationMode = options.AuthenticationMode,
                AuthenticationType = options.AuthenticationType,
                Description = options.Description,
                Provider = new ApplicationOAuthBearerProvider(),
                SystemClock = options.SystemClock
            });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = options.AccessTokenFormat,
                AccessTokenProvider = options.AccessTokenProvider,
                AuthenticationMode = AuthenticationMode.Passive,
                AuthenticationType = "ExternalBearer",
                Description = options.Description,
                Provider = new ExternalOAuthBearerProvider(),
                SystemClock = options.SystemClock
            });
        }
    }
}
