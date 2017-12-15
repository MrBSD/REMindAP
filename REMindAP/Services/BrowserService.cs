using Microsoft.AspNetCore.SignalR;
using REMindAP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMindAP.Services
{
    public class BrowserNotificationService: Hub
    {
        public async Task Send(Notification notification)
        {
            await Clients.All.InvokeAsync("Notify", notification);
        }
    }
}
