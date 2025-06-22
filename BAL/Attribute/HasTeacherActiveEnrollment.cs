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
    public class HasTeacherActiveEnrollmentAttribute:ValidationAttribute
    {
        ITeacherService _teacher;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _teacher = (ITeacherService)validationContext.GetService(typeof(ITeacherService));
            if (_teacher == null)
                return new ValidationResult(ErrorMessage);
            clsEnrolmentTeacherInClassModel model = validationContext.ObjectInstance as clsEnrolmentTeacherInClassModel;
            if (_teacher.HasActiveEnrollmentTeacher((int)value, model.ClassID))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
