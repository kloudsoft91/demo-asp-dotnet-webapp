using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWebApplication.Models
{
    public class ParkingCostModel
    {
        [Required(ErrorMessage = "Please enter time and date of start of parking")]
        public DateTime ParkingStart { get; set; }

        [Required(ErrorMessage = "Please enter time and date of end of parking")]
        public DateTime ParkingEnd { get; set; }

        [Required(ErrorMessage = "Please select the type you belong to")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter your car registration")]
        public string Rego { get; set; }
    }
}
