using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.interfaceCalsses;
using BAL.IService;
using BAL.Attribute;
using Microsoft.AspNetCore.Http;

namespace BAL.ViewModel
{
    public class clsPersonViewModel
    {


        public clsPersonViewModel()
        {
                BirthDate = DateTime.Now;
        }

        [Display(Name = "معرف الشخص")]
        public int PersonID { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "الرقم الوطني يجب أن يحتوي على 11 رقم.")]
        [Display(Name = "الرقم الوطني")]
        [UniquNatiunalNumber(ErrorMessage ="هذا الرقم مستخدم بالفعل")]
        public string NationalNumber { get; set; }

        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "الاسم الاول")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "اسم الاب")]
        public string FatherName { get; set; }

        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "اسم الجد")]
        public string GrandFatherName { get; set; }

        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "الكنية")]
        public string LastName { get; set; }

        [RegularExpression(@"^0\d{10}$", ErrorMessage = "رقم الهاتف يجب أن يبدأ بـ 0 ويحتوي على 11 رقمًا.")]
        [Display(Name = "رقم الهاتف")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "اسم الام")]
        public string MotherName { get; set; }
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [Display(Name = "كنية الام")]
        public string MotherLastName { get; set; }

        [Display(Name ="الحالة الاجتماعية")]
        public int RelationshipsID {  get; set; }

        [Display(Name ="الجنس")]
        public bool Gendor { get; set; }
        [Display(Name ="مكان الولادة")]
        public int PlaceOfBirthID { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name ="الصورة الشخصية")]
        public IFormFile ImageFile { get; set; }
        public string? ImagePath {  get; set; }
        public string? NationalIDImage { get; set; }


        //public int? AuditableEntityID { get; set; }

        //public virtual AuditableEntity AuditableEntity { get; set; }

       public  clsAddressPartialView addressPartialView { get; set; }
       public clsCityAndCountryViewModel CityAndCountry { get; set; }
    }
}
