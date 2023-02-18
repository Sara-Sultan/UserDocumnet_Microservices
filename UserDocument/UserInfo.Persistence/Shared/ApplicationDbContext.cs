using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Domain.Entities;
using Document.Domain.MapEntities;

namespace Document.Persistence.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserDocument> UserDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MapEntities(modelBuilder);

        }
        private void MapEntities(ModelBuilder modelBuilder)
        {
            new UserDocumentMap(modelBuilder.Entity<UserDocument>());
        }
        public void Save()
        {
            this.SaveChanges();
        }
    }
}