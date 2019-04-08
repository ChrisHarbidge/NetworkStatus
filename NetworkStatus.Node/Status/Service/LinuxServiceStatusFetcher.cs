using NetworkStatus.Node.Exceptions;
using System.IO;

namespace NetworkStatus.Node.Status.Service
{
    class LinuxServiceStatusFetcher
    {
        public bool ServiceIsRunning(ILinuxService service)
        {
            if (File.Exists(service.ProcessIdFolder()) == false)
            {
                throw new ServiceNotInstalledException(service.ServiceName());
            }

            // On linux, if a .pid exists, then the process must be running
            return File.Exists(Path.Combine(service.ProcessIdFolder(), service.ProcessIdFileName()));
        }
    }
}
