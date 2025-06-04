using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.EF
{
    public class AppDBContext:DbContext
    {
        public AppDBContext():base()
        {
        }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
      public  DbSet<clsAddress> Addresses { get; set; }
       public DbSet<clsCity> Cities { get; set; }
       public DbSet<AuditableEntity> AuditableEntities { get; set; }
       public DbSet<clsClass> Classes { get; set; }
       public DbSet<clsCountriy> Countriys { get; set; }
       public DbSet<clsDepartment> Departments { get; set; }
       public DbSet<clsEnrolmentStudentInClass> EnrolmentStudent { get; set; }
       public DbSet<clsEnrolmentTeacherInClass> EnrolmentTeachers { get;set; } 
       public DbSet<clsNeighborhood> Neighborhoods { get; set; }
       public DbSet<clsPayment> Payments { get; set; }
       public DbSet<clsPerson> People { get; set; }
       public DbSet<clsStudent > Students { get; set; }
       public DbSet<clsTeacher> Teachers { get; set; }
       public DbSet<clsDistrict> Districts { get; set; }

    }
}
