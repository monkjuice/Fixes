using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAPI
{
    public class FixesHub
    {
        public static HubConnection HubConnection { get; set; }
    }
}
