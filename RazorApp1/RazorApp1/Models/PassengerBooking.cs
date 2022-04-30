using System.ComponentModel.DataAnnotations;

namespace RazorApp1.Models
{
    public class PassengerBooking
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "FlightCode is required.")]
        public string FlightCode { get; set; }
    }
}
