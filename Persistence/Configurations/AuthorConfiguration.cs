using Domain.Author;
using Domain.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasConversion(
                AuthorId => AuthorId.Value,
                value => new AuthorId(value));
            builder.Property(a => a.FullName).HasMaxLength(100);
            builder.HasIndex(a => a.FullName).IsUnique();

        }
    }
}
