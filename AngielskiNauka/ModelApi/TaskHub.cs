using Microsoft.AspNetCore.SignalR;

namespace AngielskiNauka.ModelApi
{
    public class TaskHub : Hub
    {
        public async Task NotifyNewTask(string title, string description)
        {
            // Wysyłanie do wszystkich klientów (oprócz nadawcy - opcjonalnie)
            await Clients.Others.SendAsync("NewTaskNotification", title, description);
        }
    }

}
