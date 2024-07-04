using Owin;
using Microsoft.Owin.Cors;
using System.Net.Http;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace TodoSPA48
{
    //public partial class Startup
    //{
    //    public void ConfigureAuth(IAppBuilder app)
    //    {
    //        app.UseWindowsAzureActiveDirectoryBearerAuthentication(
    //            new WindowsAzureActiveDirectoryBearerAuthenticationOptions
    //            {
    //                Audience = ConfigurationManager.AppSettings["ida:Audience"],
    //                Tenant = ConfigurationManager.AppSettings["ida:Tenant"]
    //            });
    //    }
    //}

    public partial class Startup
    {
        private readonly string _authority = $"{ConfigurationManager.AppSettings["ida:AADInstance"]}/{ConfigurationManager.AppSettings["ida:TenantId"]}/v2.0";
        private readonly string _audience = ConfigurationManager.AppSettings["ida:ClientId"];

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = _audience,
                    ValidateIssuer = true,
                    ValidIssuer = _authority,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = GetIssuerSigningKeys(_authority).Result
                }
            });
        }

        private async Task<IEnumerable<SecurityKey>> GetIssuerSigningKeys(string authority)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var openIdConfigUrl = $"{authority}/.well-known/openid-configuration";
                    var openIdConfigResponse = await httpClient.GetStringAsync(openIdConfigUrl);
                    var openIdConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenIdConnectConfiguration>(openIdConfigResponse);
                    var jsonWebKeySetResponse = await httpClient.GetStringAsync(openIdConfig.JwksUri);
                    var jsonWebKeySet = new JsonWebKeySet(jsonWebKeySetResponse);
                    return jsonWebKeySet.GetSigningKeys();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
