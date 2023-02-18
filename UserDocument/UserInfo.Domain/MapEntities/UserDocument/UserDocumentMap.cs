using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Domain.Entities;

namespace Document.Domain.MapEntities
{
    public class UserDocumentMap
    {
        public UserDocumentMap(EntityTypeBuilder<UserDocument> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.Property(t => t.UserId).IsRequired();
            entityBuilder.Property(t => t.FilePath).IsRequired();

            entityBuilder.HasIndex(u => u.UserId).IsUnique();

        }
    }
}
