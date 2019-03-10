using System;
using System.ComponentModel.DataAnnotations;
using TestEV.ViewModels;

namespace TestEV.Models
{
    public class Event
    {
        [Key]
        public int Id_event { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int NumberOfSeats { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public Event()
        {

        }

        public Event(EventViewModel eventModel)
        {
            Name = eventModel.Name;
            Theme = eventModel.Theme;
            Location = eventModel.Location;
            Description = eventModel.Description;
            NumberOfSeats = eventModel.NumberOfSeats;
            Date = eventModel.Date;
            Time = eventModel.Time;
        }
    }
}