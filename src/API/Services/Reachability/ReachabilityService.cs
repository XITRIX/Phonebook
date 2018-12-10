using System;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
namespace Phonebook.API.Services.Reachability
{
    public class ReachabilityService : IReachabilityService
    {
        private IConnectivity Connectivity { get; }

        public ReachabilityService()
        {
            Connectivity = CrossConnectivity.Current;
        }

        public bool IsConnected()
        {
            return Connectivity.IsConnected;
        }

        public void AddConnectionChangedEvent(Action<bool> action)
        {
            Connectivity.ConnectivityChanged += (sender, e) =>
            {
                action(IsConnected());
            };
        }
    }
}
