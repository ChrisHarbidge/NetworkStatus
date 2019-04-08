namespace NetworkStatus.Node.Status.Service.Plex
{
    class PlexMediaServerService : ILinuxService
    {
        public string ProcessIdFileName() => "plexmediaserver.pid";
        
        public string ProcessIdFolder() => @"/var/lib/plexmediaserver/Library/Application\ Support/Plex\ Media\ Server/";

        public string ServiceName() => "Plex Media Server";
    }
}
