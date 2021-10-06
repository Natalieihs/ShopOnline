using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace Web
{
    public class NotifyHub : Hub
    {
        private readonly RandomCatalogPriceService _catalogPriceService;
        public NotifyHub(RandomCatalogPriceService catalogPriceService)
        {
            _catalogPriceService = catalogPriceService;
            _catalogPriceService.Start();
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
