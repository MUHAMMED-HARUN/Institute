using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsMember
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        public virtual clsGroup Group { get; set; }
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public virtual clsPerson Person { get; set;}
    }
}
