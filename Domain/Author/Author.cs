using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Author
{
    public class Author
    {
        private Author() { }
        public Author(AuthorId id, string FullName, DateTime Birthday) 
        {
            this.Id = id;
            this.FullName = FullName;
            this.Birthday = Birthday;
        }

        public AuthorId Id { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public DateTime Birthday { get; private set; }
    }
}
