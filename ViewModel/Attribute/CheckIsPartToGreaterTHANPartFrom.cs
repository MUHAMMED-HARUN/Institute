using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Attribute
{
    public class CheckIsPartToGreaterTHANPartFromAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           
            //ob model = validationContext.ObjectInstance as clsNomination;
            //if (!(model.ToPart >= model.FromPart))
            //    return new ValidationResult(ErrorMessage);
            //else
                return ValidationResult.Success;
        }
    }
}
