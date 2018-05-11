﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Cibertec.Mvc.Startup))]
namespace Cibertec.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "CibertecCookie",
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}