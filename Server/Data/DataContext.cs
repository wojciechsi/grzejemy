
using Microsoft.EntityFrameworkCore;
using grzejemy.Server.Models;

namespace grzejemy.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=servergrzejemy.database.windows.net;Initial Catalog=grzejemy;User ID=azureuser;Password=grzejemy123!");
        }

        //public DbSet<Buyer> Buyers { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Offer> Offers { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        //public DbSet<SalesPoint> SalesPoints { get; set; }
        //public DbSet<User> Users { get; set; }


    }
}
