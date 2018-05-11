using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Cibertec.Mvc.Hubs
{
    public class UserHub : Hub
    {
        public void EditValidate(string userName)
        {
            Clients.Others.onEditValidate(userName);
        }
    }
}