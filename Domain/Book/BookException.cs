using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Book
{
    public sealed class BookNotFoundException : Exception
    {
        public BookNotFoundException(BookId id)
            : base($"Книга с id = {id.Value} не была найдена")
        {
        }
    }
}
