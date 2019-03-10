using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestEV.Models;

namespace TestEV.Services
{
    public class EventServices
    {
        public class EventService : IEventService
        {
            private readonly ApplicationDbContext context = new ApplicationDbContext();

            public IEnumerable<Event> GetEvents()
            {
                return context.Events;
            }

            public Event GetEvent(int id)
            {
                return context.Events.SingleOrDefault(ev => ev.Id_event == id);
            }

            public void CreateEvent(Event newEvent)
            {
                context.Events.Add(newEvent);
                context.SaveChanges();
            }

            public void JoinEvent(Event eventEntity, string userId)
            {
                context.UserEvents.Add(new UserEvents
                {
                    EventId = eventEntity.Id_event,
                    UserId = userId
                });
                eventEntity.NumberOfSeats--;
                context.Entry(eventEntity).State = EntityState.Modified;
                context.SaveChanges();
            }

            public IEnumerable<int> GetUserEvents(string userId)
            {
                return context.UserEvents.Where(ev => ev.UserId == userId).Select(x=>x.EventId).ToList();
            }

            bool IEventService.IsUserJoined(string userId, int eventId)
            {
                return context.UserEvents.Any(x => x.UserId == userId && x.EventId == eventId);
            }
        }
    }
}