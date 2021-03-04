using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarBuilder.Entities
{
    public class Garagee
    {
        [Key]
        public int GarageID { get; set; }
        public string CarID { get; set; }
        
        public string ClientID { get; set; }

        [ForeignKey("CarID")]
        public Car Car { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }
    }
}
