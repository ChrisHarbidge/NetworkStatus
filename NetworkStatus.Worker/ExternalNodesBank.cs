using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NetworkStatus.Worker
{
    public interface IExternalNodesBank
    {
        void AddAddress(IPAddress address);
        List<IPAddress> GetKnownHosts();
    }

    public class ExternalNodesBank : IExternalNodesBank
    {
        private ConcurrentDictionary<IPAddress, DateTime> _externalNodes = new ConcurrentDictionary<IPAddress, DateTime>();
        
        public void AddAddress(IPAddress address)
        {
            _externalNodes[address] = DateTime.Now;
        }

        public List<IPAddress> GetKnownHosts()
        {
            Cleanup();
            return _externalNodes.Keys.ToList();
        }

        private void Cleanup()
        {
            var expiryDate = DateTime.Now.AddSeconds(-60);
            _externalNodes.Where(pair => pair.Value < expiryDate)
                .Select(pair => pair.Key)
                .ToList()
                .ForEach(key => _externalNodes.Remove(key, out _));
        }
    }
}