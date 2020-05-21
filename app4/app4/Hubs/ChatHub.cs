using app4.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app4.Hubs
{
    public class ChatHub: Hub
    {
        public async Task Send(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
