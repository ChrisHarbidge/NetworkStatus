using NetworkStatus.Node.Exceptions;
using System.IO;

namespace NetworkStatus.Node.Status.Service
{
    public interface ILinuxServiceStatusFetcher
    {
        LinuxServiceStatus ServiceIsRunning(ILinuxService service);
    }

    public class LinuxServiceStatusFetcher : ILinuxServiceStatusFetcher
    {
        public LinuxServiceStatus ServiceIsRunning(ILinuxService service)
        {
            if (Directory.Exists(service.ProcessIdFolder()) == false)
            {
                throw new ServiceNotInstalledException(service.ServiceName());
            }

            // On linux, if a .pid exists, then the process must be running
            var processFileExists = File.Exists(Path.Combine(service.ProcessIdFolder(), service.ProcessIdFileName()));

            return new LinuxServiceStatus
            {
                IsRunning = processFileExists,
                ServiceName = service.ServiceName()
            };
        }
    }
}
