using System.ComponentModel.DataAnnotations;

namespace CarBuilder.ViewModels.NewCar
{
    public class CreateVM
    {
        [Required(ErrorMessage = "*This field is required")]
        public string CarID { get; set; }

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
