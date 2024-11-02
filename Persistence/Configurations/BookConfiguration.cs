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
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasConversion(
                BookId => BookId.Value,
                value => new BookId(value));
            builder.Property(b => b.AuthorId).HasConversion(
                AuthorId => AuthorId.Value,
                value => new AuthorId(value));
            builder.Property(b => b.Title).HasMaxLength(255);
            builder.Property(b => b.Genre).HasMaxLength(100);

            builder.HasOne(book => book.Author)
                .WithMany()
                .HasForeignKey(author => author.AuthorId)
                .IsRequired();
        }
    }
}
