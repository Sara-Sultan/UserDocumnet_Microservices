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
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired().HasMaxLength(20);
            entityBuilder.Property(t => t.MiddleName).IsRequired().HasMaxLength(40);
            entityBuilder.Property(t => t.LastName).IsRequired().HasMaxLength(20);

            entityBuilder.Property(t => t.BirthDate).IsRequired();
            entityBuilder.Property(t => t.MobileNumber).IsRequired().HasMaxLength(15);
            entityBuilder.Property(t => t.Email).IsRequired();


            entityBuilder.HasMany<Address>(g => g.Addresses)
              .WithOne(s => s.User)
              .HasForeignKey(s => s.UserId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
