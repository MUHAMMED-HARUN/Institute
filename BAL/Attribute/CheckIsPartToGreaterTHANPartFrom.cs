using BAL.interfaceCalsses;
using BAL.ViewModel;
using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Attribute
{
    public class CheckIsPartToGreaterTHANPartFromAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           
            clsNomination model = validationContext.ObjectInstance as clsNomination;
            if (!(model.ToPart>=model.FromPart))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
