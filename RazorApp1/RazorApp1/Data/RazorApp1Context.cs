#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorApp1.Extensions;
using RazorApp1.Models;

namespace RazorApp1.Data
{
    public class RazorApp1Context : DbContext
    {
        public RazorApp1Context (DbContextOptions<RazorApp1Context> options)
            : base(options)
        {
        }

        public DbSet<RazorApp1.Models.Airport> Airport { get; set; }
        public DbSet<RazorApp1.Models.Flight> Flight { get; set; }
        public DbSet<RazorApp1.Models.Plane> Plane { get; set; }
        public DbSet<RazorApp1.Models.PassengerBooking> PassengerBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
