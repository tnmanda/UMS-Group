using System.ComponentModel.DataAnnotations;

namespace RazorApp1.Models
{
    public class Plane
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        public string? Code { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Airline { get; set; }
        [Required]
        [StringLength(10)]
        public string? Model { get; set; }

    }
}
