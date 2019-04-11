using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStatus.Node.Status.Device.Network.Performance
{
    public class DownloadSpeedFetcher
    {
        public async Task<DownloadSpeed> GetDownloadSpeedMegabytes()
        {
            var watch = new Stopwatch();

            byte[] data;

            using (var client = new System.Net.WebClient())
            {
                watch.Start();

                data = await client.DownloadDataTaskAsync("http://dl.google.com/googletalk/googletalk-setup.exe?t=" + DateTime.Now.Ticks);
                watch.Stop();
            }

            var speed = data.LongLength / watch.Elapsed.TotalSeconds;

            return new DownloadSpeed { Speed = speed / 1000000 };
        }
    }
}
