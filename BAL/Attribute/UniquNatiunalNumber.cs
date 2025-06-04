using BAL.interfaceCalsses;
using BAL.IService;
using BAL.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Attribute
{
    public class UniquNatiunalNumberAttribute:ValidationAttribute
    {
        IPersonService _personService;


        public UniquNatiunalNumberAttribute()
        {
            
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _personService = (IPersonService) validationContext.GetService(typeof(IPersonService));
            clsPersonViewModel person =(clsPersonViewModel) validationContext.ObjectInstance;
            if (_personService.IsNationalNumberUnique(value.ToString(), person.PersonID))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
                
        }
    }
}
