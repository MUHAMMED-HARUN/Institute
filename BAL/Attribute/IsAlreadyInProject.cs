using BAL.interfaceCalsses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Attribute
{
    public class IsAlreadyInProjectAttribute : ValidationAttribute
    {
        IQuranStudentService _quranStudent;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _quranStudent = (IQuranStudentService)validationContext.GetService(typeof(IQuranStudentService));
            if (_quranStudent == null)
                return new ValidationResult(ErrorMessage);

            if (_quranStudent.IsQuranStudent((int)value))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
