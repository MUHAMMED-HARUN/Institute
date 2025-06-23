using BAL.interfaceCalsses;
using BAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Attribute
{
    public class IsQuranStudentHasBaseStudentAttribute : ValidationAttribute
    {
        IQuranStudentService _studentService;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _studentService = (IQuranStudentService)validationContext.GetService(typeof(IQuranStudentService));
            if (_studentService == null)
                return new ValidationResult(ErrorMessage);

            if (_studentService.IsQuranStudent((int)value))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
