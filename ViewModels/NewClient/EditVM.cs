using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.ViewModels.NewClient
{
    public class EditVM
    {
        

        [Required(ErrorMessage = "*This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string City { get; set; }

    }
}
