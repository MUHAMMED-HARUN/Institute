using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsQuranTest
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Nomination")]
        public int NominationID { get; set; }
        public virtual clsNomination Nomination { get; set; }

        [ForeignKey("Committee")]
        public int CommitteeID { get; set; }
        public virtual clsGroup Committee {  get; set; }
        public short Grade { get; set; }


    }
}
