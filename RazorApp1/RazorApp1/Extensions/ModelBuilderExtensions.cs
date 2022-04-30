using Microsoft.EntityFrameworkCore;
using RazorApp1.Models;

namespace RazorApp1.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Airport>().HasData(
                new Airport() { ID = 1, Address = "Pasay", AirportName = "MIA" },
                new Airport() { ID = 2, Address = "Taguig", AirportName = "Terminal 2" }

            );

            modelBuilder.Entity<Plane>().HasData(
                new Plane() { ID = 1, Airline = "Cebu Pacific", Code = "PLANE01", Model = "a320" },
                new Plane() { ID = 2, Airline = "PAL", Code = "PLANE02", Model = "a320" }

            );

        }
    }
}
