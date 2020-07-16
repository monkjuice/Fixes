using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace TestAPI
{
    public class SignalR
    {
        async static public Task Execute()
        {
            try
            {

                FixesHub.HubConnection = new HubConnectionBuilder()
                         .WithUrl($"https://localhost:44338/chatHub", options =>
                         {
                             options.AccessTokenProvider = () => Task.FromResult(Program.userToken);
                         })
                         .Build();

                if (FixesHub.HubConnection.State == HubConnectionState.Disconnected)
                    await FixesHub.HubConnection.StartAsync();
                    var a = "ok";
                    Execute();

                FixesHub.HubConnection.On<string, string>("ReceiveMessage", (message, userid) =>
                {

                    Console.WriteLine(message);
                    // search if conversation with recieved userid exists; add the message to the conversation or create one
                    //Messages.Add(new MessageVM()
                    //{
                    //    Body = message,
                    //    Position = LayoutOptions.Start,
                    //    UserId = int.Parse(userid),
                    //    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    //}); ;
                });


            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
