
using System.ComponentModel.DataAnnotations;

namespace CarBuilder.ViewModels.NewClient
{
    public class CreateVM
    {
        [Required(ErrorMessage = "*This field is required")]
        public string ClientID { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string City { get; set; }

        
    }
}
