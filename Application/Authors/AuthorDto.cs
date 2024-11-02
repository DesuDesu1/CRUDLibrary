using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors
{
    public record AuthorDto(
    Guid Id,
    string FullName,
    DateTime Birthday);
}
