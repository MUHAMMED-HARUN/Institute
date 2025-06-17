using BAL.interfaceCalsses;
using BAL.ViewModel;
using DAL.interfaceCalsses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Attribute
{
    public class HasActiveEnrollmentAttribute : ValidationAttribute
    {
        IStudentService _student;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _student = (IStudentService)validationContext.GetService(typeof(IStudentService));
            if (_student == null)
                return new ValidationResult(ErrorMessage);
            clsEnrolmentStudentInClassModel model= validationContext.ObjectInstance as clsEnrolmentStudentInClassModel;
            if (_student.HasActiveEnrollment((int)value, model.ClassID))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
