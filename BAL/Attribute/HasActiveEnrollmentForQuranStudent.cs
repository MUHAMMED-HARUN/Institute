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
    public class HasActiveEnrollmentForQuranStudentAttribute : ValidationAttribute
    {
        IStudentService _student;
        string _ClassIDFildName;
        public HasActiveEnrollmentForQuranStudentAttribute(string ClassIDFildName)
        {
            _ClassIDFildName = ClassIDFildName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            _student = (IStudentService)validationContext.GetService(typeof(IStudentService));
            if (_student == null)
                return new ValidationResult(ErrorMessage);


            Type TypeModle= validationContext.ObjectInstance.GetType();

            int? ClassID = (int)TypeModle.GetProperty(_ClassIDFildName).GetValue(validationContext.ObjectInstance);

            if(ClassID == null)
                return new ValidationResult("خطا غير متوقع");

            if (_student.HasActiveEnrollment((int)value,ClassID.Value))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
