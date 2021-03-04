using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.ViewModels.NewCar
{
    public class EditVM
    {
        
        

        [Required(ErrorMessage = "*This field is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string InteriorMaterial { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string InteriorColor { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string EngineDisplacement { get; set; }
    }
}
