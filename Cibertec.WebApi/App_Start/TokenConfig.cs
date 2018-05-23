using Cibertec.UnitOfWork;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Cibertec.WebApi
{
    public class TokenConfig
    {
        public static void ConfigureOAuth(IAppBuilder app, HttpConfiguration config)
        {
            var unitOfWork = (IUnitOfWork)config.DependencyResolver.GetService(typeof(IUnitOfWork));
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CibertecAuthProvider(unitOfWork)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private class CibertecAuthProvider : OAuthAuthorizationServerProvider
        {
            private IUnitOfWork unitOfWork;

            public CibertecAuthProvider(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                await Task.Factory.StartNew(() =>
                {
                    var user = unitOfWork.Users.ValidateUser(context.UserName, context.Password);
                    if (user == null)
                    {
                        context.SetError("invalid_grant", "Credenciales inválidas");
                        return;
                    }
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", user.Roles));

                    context.Validated(identity);
                });
            }
            
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                await Task.Factory.StartNew(() => { context.Validated(); });
            }            
        }
    }
}