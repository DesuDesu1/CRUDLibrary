using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    //Оболочка созданная для того, чтобы хоть немного отсоединить слой Application от FluentValidation
    public sealed class ValidationException : Exception
    {
        public IReadOnlyCollection<ValidationError> Errors { get; }    
        public ValidationException(IReadOnlyCollection<ValidationError> errors) 
        {
            Errors = errors;
        }    
    }
    public record ValidationError(string PropertyName, string ErrorMessage);

}
