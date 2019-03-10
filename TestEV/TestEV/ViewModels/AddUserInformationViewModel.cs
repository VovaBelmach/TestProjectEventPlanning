using System.ComponentModel.DataAnnotations;

namespace TestEV.ViewModels
{
    public class AddUserInformationViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Фамилия:")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Имя:")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Возраст:")]
        public int Age { get; set; }
    }
}