using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Cibertec.Mvc.Hubs
{
    public class UserHub : Hub
    {
        private class ItemEnUso
        {
            public string ConnectionId { get; set; }
            public int Id { get; set; }
            public bool MostrarMensaje
            {
                get
                {
                    var primerItem = _ids.FirstOrDefault();
                    if (primerItem != null)
                    {
                        if (primerItem.Id == this.Id && primerItem.ConnectionId == this.ConnectionId)
                            return false;
                        else
                        {
                            var estanEditando = _ids.Where(i => i.Id == this.Id && i.ConnectionId != this.ConnectionId).Count();
                            return estanEditando > 0;
                        }
                    }
                    return false;
                }
            }
        }

        static List<ItemEnUso> _ids = new List<ItemEnUso>();
        public void AddUserId(int id)
        {
            var item = new ItemEnUso { Id = id, ConnectionId = Context.ConnectionId };
            _ids.Add(item);
            Clients.All.userStatus(new { TriggerId = id, ArrayIds = _ids });
        }
        public void RemoveUserId(int id)
        {
            var item = _ids.FirstOrDefault(i => i.ConnectionId == Context.ConnectionId && i.Id == id);
            if (item != null)
                _ids.Remove(item);

            Clients.All.userStatus(new { TriggerId = id, ArrayIds = _ids });
        }
    }
}