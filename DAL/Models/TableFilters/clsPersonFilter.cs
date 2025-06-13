using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsPersonFilter
    {
        [DisplayName("المعرف الشخصي")]
        [RegularExpression(@"^\d+$", ErrorMessage = "يجب إدخال أرقام فقط")]
        public int? PersonID { get; set; }

        [DisplayName("الرقم الوطني")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "يجب إدخال أرقام فقط ويجب ان يتكون من 11 رقم")]
        public string NationalNumber { get; set; } 

        [DisplayName("الاسم الاول")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DisplayName("اسم الاب")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string FatherName { get; set; }

        [DisplayName("الكنية")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DisplayName("الاسم الكامل")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [DisplayName("اسم الام")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string MotherName {  get; set; }

        [DisplayName("كنية الام")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string MotherLastName {  get; set; }

        [DisplayName("رقم التواصل")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "يجب إدخال أرقام فقط ويجب ان يتكون من 11 رقم")]
        [DataType(DataType.Text)]
        public string PhoneNumber {  get; set; }

        [DisplayName("الى تاريخ")]
        [DataType(DataType.DateTime)]
        public DateTime? MaxDate { get; set; }

        [DisplayName("من تاريخ")]
        [DataType(DataType.DateTime)]
        public DateTime? MinDate { get; set; }

        [DisplayName("الجنس")]
        public bool? Gendor { get; set; }

        [DisplayName("الحالة الاجتماعية")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string PersonalStatus { get; set; }

        [DisplayName("الدولة")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [DisplayName("المدينة")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [DisplayName("المقاطعة")]
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "يجب ان يكون مكون من احرف فقظ")]
        [DataType(DataType.Text)]
        public string District { get; set; }

        [DisplayName("الحي")]
        [DataType(DataType.Text)]
        public string Neighborhood { get; set; }

   public   List<  clsPersonTableView >personTableView { get; set; }=new List< clsPersonTableView>();
    }
}
