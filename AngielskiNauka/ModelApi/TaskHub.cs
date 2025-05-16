using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.ObjectPool;

namespace AngielskiNauka.ModelApi
{

    public class ChatHub : Hub
    {
        public async Task SendMessage(string status, string ang,string pol)
        {
             await Clients.All.SendAsync("ReceiveMessage", status,ang,pol);
        }
    }

}
