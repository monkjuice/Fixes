using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Model;

namespace FixesAPI.RealTime
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string to, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", to, message);
        }
    }
}
