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

namespace RazorApp1.Pages.FlightPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

       
        public SelectList AirportList { get; set; }
        public SelectList PlaneList { get; set; }

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


        public CreateModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {  

            PopulateAirportsDropDownList();
            PopulatePlanesDropDownList();

            return Page();
        }

        [BindProperty]
        public Flight Flight { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Flight.Add(Flight);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
