using System.Collections.Generic;
using TestEV.Models;

namespace TestEV.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();

        IEnumerable<int> GetUserEvents(string userId);

        Event GetEvent(int id);

        bool IsUserJoined(string userId, int eventId);

        void CreateEvent(Event newEvent);

        void JoinEvent(Event eventEntity, string userId);
    }
}