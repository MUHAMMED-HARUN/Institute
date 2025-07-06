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
    public class HasActiveQuranTestNominationAttribute:ValidationAttribute
    {
        ITestService _TestServ;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
             _TestServ= (ITestService)validationContext.GetService(typeof(ITestService));
            if (_TestServ == null)
                return new ValidationResult(ErrorMessage);
            clsNominationModel model = validationContext.ObjectInstance as clsNominationModel;
            if (_TestServ.HasActiveQuranTsetNomination( model.QuranStudentID, (int)value))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
