using NetworkStatus.Node.Status;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Client.Api
{
    interface IApiClient
    {
        Task SyncStatusAsync(NodeStatus status);
    }
}
