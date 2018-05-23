using System;
using System.Threading.Tasks;
using System.Web.Http;
using Cibertec.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Cibertec.WebApi.Startup))]

namespace Cibertec.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            DIConfig.ConfigureInjector(config);
            app.UseCors(CorsOptions.AllowAll);
            TokenConfig.ConfigureOAuth(app, config);
            RouteConfig.Register(config);
            WebApiConfig.Configure(config);
            app.UseWebApi(config);//es 'Clave' para que funcione el WebApi
        }
    }
}
