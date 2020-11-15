using System.IO;

namespace NetworkStatus.Node.Status.Service
{
    public interface IInstalledServiceVerifier
    {
        bool ServiceIsInstalled(ILinuxService service);
    }

    public class InstalledServiceVerifier : IInstalledServiceVerifier
    {
        private const string ServiceFolder = "/etc/init.d";
        
        public bool ServiceIsInstalled(ILinuxService service)
        {
            var serviceFilePath = Path.Combine(ServiceFolder, service.ServiceName());

            return Directory.Exists(serviceFilePath);
        }
    }
}