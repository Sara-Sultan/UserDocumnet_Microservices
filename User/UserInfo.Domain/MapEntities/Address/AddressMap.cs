using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;

namespace UserInfo.Domain.MapEntities
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);

            entityBuilder.HasOne<Governate>(s => s.Governate)
            .WithMany(g => g.Addresses)
            .HasForeignKey(s => s.GovernateId);

            entityBuilder.HasOne<City>(s => s.City)
            .WithMany(g => g.Addresses)
            .HasForeignKey(s => s.CityId);

            entityBuilder.HasOne<User>(s => s.User)
           .WithMany(g => g.Addresses)
           .HasForeignKey(s => s.UserId);

            entityBuilder.Property(t => t.Street).IsRequired().HasMaxLength(200);
            entityBuilder.Property(t => t.BuildingNumber).IsRequired();
            entityBuilder.Property(t => t.FlatNumber).IsRequired();
        }
    }
}
