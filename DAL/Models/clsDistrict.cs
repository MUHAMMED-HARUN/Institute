using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("District")]
    public class clsDistrict
    {
        [Key]
        public int ID { get; set; }
        public string DistrictName { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
        public virtual clsCity City { get; set; }
    }
}
