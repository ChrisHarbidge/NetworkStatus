using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Client.Api
{
    interface IApiClient
    {
        Task SyncStatusAsync(NodeStatus status);
    }
}
