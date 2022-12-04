using grzejemy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace grzejemy.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Comment> Comment { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer("DefaultConnection");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<SalesPoint>()
            //    .HasOne(s => s.Vendor)
            //    .GetType()
                
        }
       

    }
}