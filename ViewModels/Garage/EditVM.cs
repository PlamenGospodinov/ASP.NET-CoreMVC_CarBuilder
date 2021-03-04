using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.ViewModels.Garage
{
    public class EditVM
    {
        public int GarageID { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string CarID { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string ClientID { get; set; }

    }
}
