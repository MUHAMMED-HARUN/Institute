using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    
    public class clsPerson
    {
        [Key]
        public int PersonID { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "الرقم الوطني يجب أن يحتوي على 11 رقم.")]
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^0\d{10}$", ErrorMessage = "رقم الهاتف يجب أن يبدأ بـ 0 ويحتوي على 11 رقمًا.")]
        public string PhoneNumber { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual clsAddress Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public sbyte RelationshipStatus{ get; set; }
        public bool Gendor { get; set; }
        public int PlaceOfBirthID { get; set; }
        public string? Image {  get; set; }
        public string? NationalIDImage { get; set; }

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }

    }
}
