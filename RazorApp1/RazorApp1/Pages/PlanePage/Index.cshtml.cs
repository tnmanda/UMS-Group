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

namespace RazorApp1.Pages.PlanePage
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp1.Data.RazorApp1Context _context;

        public IndexModel(RazorApp1.Data.RazorApp1Context context)
        {
            _context = context;
        }

        public IList<Plane> Plane { get;set; }

        public async Task OnGetAsync()
        {
            Plane = await _context.Plane.ToListAsync();
        }
    }
}
