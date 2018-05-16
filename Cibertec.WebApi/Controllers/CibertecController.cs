using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cibertec.WebApi.Controllers
{
    public class CibertecController : ApiController
    {
        public string Get()
        {
            return "Hola Mundo - Web API";
        }
    }
}