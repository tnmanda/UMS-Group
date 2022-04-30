using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorApp1.Models
{
    public class Flight
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "FlightCode is required.")]
        public string FlightCode { get; set; }
        [Required(ErrorMessage = "Airport is required.")]
        public string Airport { get; set; }
        [Required(ErrorMessage = "Plane is required.")]
        public string Plane { get; set; }
        
    }
}
