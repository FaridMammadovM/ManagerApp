using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Hubs
{
    public interface IMesssageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }
}
