using System;
namespace Phonebook.API.Services.Reachability
{
    public interface IReachabilityService
    {
        bool IsConnected();
        void AddConnectionChangedEvent(Action<bool> action);
    }
}
