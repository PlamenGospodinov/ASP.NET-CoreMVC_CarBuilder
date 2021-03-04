using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.Entities
{
    public class Car
    {
        [Key]
        public string CarID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string InteriorMaterial { get; set; }

        public string InteriorColor { get; set; }

        public string EngineDisplacement { get; set; }
    }
}
