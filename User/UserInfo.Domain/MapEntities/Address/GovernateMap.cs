using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;

namespace UserInfo.Domain.MapEntities
{
    public class GovernateMap
    {
        public GovernateMap(EntityTypeBuilder<Governate> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.HasMany<Address>(g => g.Addresses)
               .WithOne(s => s.Governate)
               .HasForeignKey(s => s.GovernateId)
               .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(t => t.Name).IsRequired().HasMaxLength(200);
        }
    }
}
