namespace NetworkStatus.Node.Status.Service
{
    interface ILinuxService
    {
        string ProcessIdFolder();
        string ProcessIdFileName();
        string ServiceName();
    }
}
