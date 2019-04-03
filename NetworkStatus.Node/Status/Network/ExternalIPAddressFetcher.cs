using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Network
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

                        return  data;
                    }
                }
            }
        }
    }
}
