#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorApp1.Data;
using RazorApp1.Models;

namespace RazorApp1.Pages.BookingPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public SelectList FlightList { get; set; }

        public CreateModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;

            PopulateAirportsDropDownList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PassengerBooking PassengerBooking { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PassengerBooking.Add(PassengerBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void PopulateAirportsDropDownList()
        {
            var FlightQuery = _context.Flight.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.ID.ToString(),
                                      Text = a.FlightCode
                                  });

            FlightList = new SelectList(FlightQuery, "Text", "Text");

        }
    }
}
