using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Hubs
{
    public class MyBusiness
    {
        readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SenMessageAsync(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
