using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsPayment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("EnrolmentStudentInClass")]
        public int StudentEnrollmentId { get; set; }
        public virtual clsEnrolmentStudentInClass EnrolmentStudentInClass { get; set; }
        public DateTime PaymentDate { get; set; }
        public float PaidAmount { get; set; }
        public float AmountDue { get; set; }
    }
}
