using Booking.Model.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System.Xml.Schema;


namespace Booking.Model.Database
{
    public class ApplicationContext:DbContext
    {
        //public ApplicationContext() : base("DefaultConnection")
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Phones;Trusted_Connection=True; TrustServerCertificate=True;");
        }
        public DbSet<Phone> Phones { get; set; }
    }
}
