using BAL.interfaceCalsses;
using BAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.interfaceCalsses;
namespace BAL.Attribute
{
    class IsStudentAttribute: ValidationAttribute
    {
         IStudentService _studentService;
        public IsStudentAttribute()
        {

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _studentService = (IStudentService)validationContext.GetService(typeof(IStudentService));
            clsStudentViewModel StudentModel = (clsStudentViewModel)validationContext.ObjectInstance;

            if (_studentService.IsExist(StudentModel.StudentID ?? -1))
                if (_studentService.IsUniqueStudent((int)value, StudentModel.StudentID.Value))
                {
                    return ValidationResult.Success;
                }
                else
                    return new ValidationResult(ErrorMessage);
                

            if (!_studentService.IsStudent((int)value))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);

        }
    }
}
