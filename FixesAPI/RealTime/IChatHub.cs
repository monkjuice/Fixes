using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixesAPI.RealTime
{
    public interface IChatHub
    {
        public void QueueChatMessage(string who, string message);

        public void SendChatMessage(string who, byte[] message);

        public void MessageRecieved(string messageId);
    }
}
