using System.Threading.Tasks;
using NetworkStatus.Node.Status;

namespace NetworkStatus.Node.Client
{
    interface IApiClient
    {
        Task SyncStatusAsync(NodeStatus status);
    }
}
