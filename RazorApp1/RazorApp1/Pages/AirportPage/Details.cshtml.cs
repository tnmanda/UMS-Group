#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp1.Data;
using RazorApp1.Models;

namespace RazorApp1.Pages.AirportPage
{
    public class DetailsModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public DetailsModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
        }

        public Airport Airport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport = await _context.Airport.FirstOrDefaultAsync(m => m.ID == id);

            if (Airport == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
