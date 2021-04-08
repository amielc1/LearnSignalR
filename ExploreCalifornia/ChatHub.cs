using ExploreCalifornia.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia
{
    public class ChatHub:Hub
    {

        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync(
                "ReceiveMessage",
                "Amiel",
                DateTimeOffset.UtcNow,
                "Hi, Wellcome !!! What can i help you ? ");

            a base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SentAt = DateTimeOffset.Now
            };

            await Clients.All.SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SentAt,
                message.Text);
        }
    }
}
