using Crud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Service
{
    public static class ValidationLine
    {
        public static StringBuilder Validation(User contextUser)
        {
            var error = new StringBuilder();
            var validationContext=new ValidationContext(contextUser); 
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(contextUser,validationContext,validationResult))
            {
                foreach(var item in validationResult)
                {
                    error.AppendLine(item.ErrorMessage);
                }
            }
            return error;
        }
    }
}
