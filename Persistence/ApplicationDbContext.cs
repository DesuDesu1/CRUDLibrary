using Domain.Author;
using Domain.Book;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using MediatR;
namespace Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Author>().HasData(
                new Author(new AuthorId(Guid.NewGuid()), "Nick Giovanni", DateTime.UtcNow),
                new Author(new AuthorId(Guid.NewGuid()), "Erik Ishi", DateTime.UtcNow));
        }
    }
}
