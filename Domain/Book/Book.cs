using Domain.Author;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Book
{
    public class Book
    {
        private Book () {  }
        public Book(BookId id, string title, AuthorId authorId, Author.Author author, DateTime year, string genre)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Author = author;
            PublishedYear = year;
            Genre = genre;
        }

        public BookId Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public AuthorId AuthorId { get; private set; }
        // Добавлено для удобства Include в EF, хоть и потенциально нарушает DDD
        public Author.Author Author { get; private set; }
        public DateTime PublishedYear { get; private set; }
        public string Genre { get; private set; } = string.Empty;
        public void Update(string title, AuthorId authorId, DateTime year, string genre)
        {
            Title = title;
            AuthorId = authorId;
            PublishedYear = year;
            Genre = genre;
        }
    }
}
