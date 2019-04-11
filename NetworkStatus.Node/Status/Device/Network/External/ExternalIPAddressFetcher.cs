using System.Net.Http;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device.Network.External
{
    class ExternalIPAddressFetcher
    {
        private const string ExternalIPApi = "https://api.ipify.org";

        public async Task<string> FetchExternalIPAddress()
        {
            using (var client = new HttpClient())
            {
                using (var responseMessage = await client.GetAsync(ExternalIPApi))
                {
                    using (var content = responseMessage.Content)
                    {
                        var data = content.ReadAsStringAsync().Result;

                        return data;
                    }
                }
            }
        }
    }
}
