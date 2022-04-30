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

namespace RazorApp1.Pages.AirportPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public CreateModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Airport Airport { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Airport.Add(Airport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
