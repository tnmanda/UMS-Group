﻿#nullable disable
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

namespace RazorApp1.Pages.PlanePage
{
    public class EditModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public EditModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Plane Plane { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plane = await _context.Plane.FirstOrDefaultAsync(m => m.ID == id);

            if (Plane == null)
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

            _context.Attach(Plane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(Plane.ID))
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

        private bool PlaneExists(int id)
        {
            return _context.Plane.Any(e => e.ID == id);
        }
    }
}
