using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool  // newlememek için . ile gelmesi için static
    {
        public static  void Validate(IValidator validator,object entity) // entity,dto hepsini ekleyebiliriz hepsinin basei 
        {
            var context = new ValidationContext<object>(entity);
            
            var result = validator.Validate(context);
            if (!result.IsValid) //geçersiz ise
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
