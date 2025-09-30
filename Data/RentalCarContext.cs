using RIRentalCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIRentalCar.Data
{
    public class RentalCarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\HP\\OneDrive\\Radna površina\\Inf 2\\Objektno programiranje\\Zavrsni_ispit_finale\\RIRentalCar\\RIRentalCar\\RentalCarDB.db");
        }
    }
}
