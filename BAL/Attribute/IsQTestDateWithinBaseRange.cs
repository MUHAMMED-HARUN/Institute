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
    public class IsQTestDateWithinBaseRangeAttribute : ValidationAttribute
    {
        ITestService _testService {  get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
          _testService=(ITestService)  validationContext.GetService(typeof(ITestService));
            if (_testService == null)
                return new ValidationResult("حدث خطا ما");

            clsNominationModel model= (clsNominationModel)validationContext.ObjectInstance;

            clsBasicTestInfo basicTestInfo = _testService.GetBasicTestInfo(model.BasicTestID);

            if (basicTestInfo == null)
                return new ValidationResult("حدث خطا ما");
            if (basicTestInfo.StartDate >= (DateTime)value &&
                basicTestInfo.EndDate <= (DateTime)value)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
