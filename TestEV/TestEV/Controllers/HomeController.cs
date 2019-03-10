using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TestEV.Models;
using TestEV.Services;
using TestEV.ViewModels;
using static TestEV.Services.EventServices;

namespace TestEV.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEventService eventService = new EventService();

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Events = eventService.GetEvents();
            ViewBag.MyEventsIds = eventService.GetUserEvents(User.Identity.GetUserId());
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateEvent(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                eventService.CreateEvent(new Event(eventViewModel));
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult CheckInfoAboutEvent(int id)
        {
            var itemEvent = eventService.GetEvent(id);
            ViewBag.Id = itemEvent;
            ViewBag.MyEvent = eventService.IsUserJoined(User.Identity.GetUserId(), id);
            return View("CheckInfoAboutEvent", itemEvent);
        }

        [HttpPost]
        [Authorize]
        public ActionResult JoinEvent(int id)
        {
            var user = User.Identity.GetUserId();
            var eventEntity = eventService.GetEvent(id);


            if (ModelState.IsValid)
            {
                if (eventEntity == null || eventEntity.NumberOfSeats == 0)
                {
                    ModelState.AddModelError(string.Empty, Resources.Event_NoSeats);
                }
                else
                {
                    if (!eventService.GetUserEvents(user).ToList().Contains(eventEntity.Id_event))
                    {
                        eventService.JoinEvent(eventEntity, user);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}