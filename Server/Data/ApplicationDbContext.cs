using Duende.IdentityServer.EntityFramework.Options;
using grzejemy.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace grzejemy.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //public DbSet<Buyer> Buyers { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Offer> Offers { get; set; }
        //public DbSet<FuelType> FuelTypes { get; set; }
        //public DbSet<SalesPoint> SalesPoints { get; set; }
        //public DbSet<User> Users { get; set; }

    }
}