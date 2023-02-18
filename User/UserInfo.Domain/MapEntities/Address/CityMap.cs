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
    public class CityMap
    {
        public CityMap(EntityTypeBuilder<City> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.HasMany<Address>(g => g.Addresses)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(t => t.Name).IsRequired().HasMaxLength(200);


          
        }
    }
}
