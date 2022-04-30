using System.ComponentModel.DataAnnotations;

namespace RazorApp1.Models
{
    public class Airport
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "AirportName is required.")]
        public string AirportName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100)]
        public string? Address { get; set; }
    }
}
