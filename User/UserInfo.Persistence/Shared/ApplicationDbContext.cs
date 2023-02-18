using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;
using UserInfo.Domain.MapEntities;

namespace UserInfo.Persistence.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Governate> Governates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MapEntities(modelBuilder);

        }
        private void MapEntities(ModelBuilder modelBuilder)
        {
            new UserMap(modelBuilder.Entity<User>());
            new AddressMap(modelBuilder.Entity<Address>());
            new CityMap(modelBuilder.Entity<City>());
            new GovernateMap(modelBuilder.Entity<Governate>());

        }
        public void Save()
        {
            this.SaveChanges();
        }
    }
}