using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Model;

namespace FixesAPI.RealTime
{
    public class ChatHub : Hub, IChatHub
    {

        public void QueueChatMessage(string who, string message)
        {
            var user = Context.GetHttpContext().User;
            string from = user.Claims.FirstOrDefault(x => x.Type == "userid").Value;

            Clients.Group(who).SendAsync("RecieveMessage", message, from);
        }

        public void SendChatMessage(string who, string message)
        {
            var user = Context.GetHttpContext().User;
            string from = user.Claims.FirstOrDefault(x => x.Type == "userid").Value;

            Clients.Group(who).SendAsync("RecieveMessage", message, from);
        }

        public void MessageRecieved(string messageId)
        {
            var user = Context.GetHttpContext().User;
            string from = user.Claims.FirstOrDefault(x => x.Type == "userid").Value;
        }

        public void SendHandshake(string who, string publicKey)
        {
            var user = Context.GetHttpContext().User;
            string from = user.Claims.FirstOrDefault(x => x.Type == "userid").Value;

            Clients.Group(who).SendAsync("RecieveHandshake", publicKey, from);
        }

        public void RespondHandshake(string who, string publicKey)
        {
            var user = Context.GetHttpContext().User;
            string from = user.Claims.FirstOrDefault(x => x.Type == "userid").Value;

            Clients.Group(who).SendAsync("HandshakeResponse", publicKey, from);
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.GetHttpContext().User;
            string username = user.Claims.FirstOrDefault(x => x.Type == "username").Value;

            Groups.AddToGroupAsync(Context.ConnectionId, username);

            return base.OnConnectedAsync();
        }

    }
}
