#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorApp1.Data;
using RazorApp1.Models;

namespace RazorApp1.Pages.BookingPage
{
    public class EditModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public SelectList FlightList { get; set; }

        public EditModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;

            PopulateAirportsDropDownList();
        }

        [BindProperty]
        public PassengerBooking PassengerBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PassengerBooking = await _context.PassengerBooking.FirstOrDefaultAsync(m => m.ID == id);

            if (PassengerBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PassengerBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerBookingExists(PassengerBooking.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PassengerBookingExists(int id)
        {
            return _context.PassengerBooking.Any(e => e.ID == id);
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
