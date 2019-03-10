using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEV.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование мероприятия:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Тема мероприятия")]
        public string Theme { get; set; }

        [Required]
        [Display(Name = "Местоположение мероприятия")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Описание мероприятия")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Количество человек на мероприятии")]
        public int NumberOfSeats { get; set; }

        [Required]
        [Display(Name = "Дата мероприятия")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Время мероприятия")]
        public DateTime Time { get; set; }
    }
}