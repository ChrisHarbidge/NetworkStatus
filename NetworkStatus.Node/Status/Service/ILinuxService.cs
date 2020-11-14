namespace NetworkStatus.Node.Status.Service
{
    public interface ILinuxService
    {
        string ProcessIdFolder();
        string ProcessIdFileName();
        string ServiceName();
    }
}
