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

namespace RazorApp1.Pages.FlightPage
{
    public class EditModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public SelectList AirportList { get; set; }
        public SelectList PlaneList { get; set; }

        public EditModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
            PopulateAirportsDropDownList();
            PopulatePlanesDropDownList();

            
        }

        [BindProperty]
        public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flight.FirstOrDefaultAsync(m => m.ID == id);

            if (Flight == null)
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

            _context.Attach(Flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(Flight.ID))
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

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.ID == id);
        }

        public void PopulateAirportsDropDownList()
        {
            var AirportQuery = _context.Airport.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.ID.ToString(),
                                      Text = a.AirportName
                                  });

            AirportList = new SelectList(AirportQuery, "Text", "Text");

        }

        public void PopulatePlanesDropDownList()
        {
            var PlaneQuery = _context.Plane.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.ID.ToString(),
                                      Text = a.Code
                                  });

            PlaneList = new SelectList(PlaneQuery, "Text", "Text");

        }

    }
}
