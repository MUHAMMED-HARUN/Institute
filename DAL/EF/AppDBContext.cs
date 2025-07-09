using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models.TableViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DAL.EF
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext() : base()
        {
        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<clsAddress> Addresses { get; set; }
        public DbSet<clsCity> Cities { get; set; }
        public DbSet<AuditableEntity> AuditableEntities { get; set; }
        public DbSet<clsClass> Classes { get; set; }
        public DbSet<clsCountriy> Countriys { get; set; }
        public DbSet<clsDepartment> Departments { get; set; }
        public DbSet<clsEnrolmentStudentInClass> EnrolmentStudent { get; set; }
        public DbSet<clsEnrolmentTeacherInClass> EnrolmentTeachers { get; set; }
        public DbSet<clsNeighborhood> Neighborhoods { get; set; }
        public DbSet<clsPayment> Payments { get; set; }
        public DbSet<clsPerson> People { get; set; }
        public DbSet<clsStudent> Students { get; set; }
        public DbSet<clsTeacher> clsTeacher { get; set; }
        public DbSet<clsDistrict> Districts { get; set; }
        public DbSet<clsReading> Readings { get; set; }
        public DbSet<clsReadingDay> ReadingDay { get; set; }
        public DbSet<clsQuranStudent> QuranStudents { get; set; }
        public DbSet<clsProject> Projects { get; set; }

        public DbSet<clsPersonTableView> PersonTableView { get; set; }
        public DbSet<clsStudentTableView> StudentTableView { get; set; }
        public DbSet<clsBasicTestInfo> BasicTestInfos { get; set; }
        public DbSet<clsQuranTest> QuranTests { get; set; }
        public DbSet<clsGroup> Groups { get; set; }
        public DbSet<clsMember> Members { get; set; }
        public DbSet<clsNomination> Nominations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<clsPersonTableView>()
                .HasNoKey() // لا يوجد مفتاح أساسي لأنه TVF
                .ToView(null); // لأن هذا ليس View فعلي في قاعدة البيانات

            modelBuilder.Entity<clsStudentTableView>()
                .HasNoKey()
                .ToView(null);
            modelBuilder.Entity<clsReading>().ToTable(rt => rt.HasTrigger("terInsertReading"));
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },

               new IdentityRole()

               {

                   Id = Guid.NewGuid().ToString(),

                   Name = "Student",

                   NormalizedName = "student",

                   ConcurrencyStamp = Guid.NewGuid().ToString(),

               },

               new IdentityRole()

               {

                   Id = Guid.NewGuid().ToString(),

                   Name = "Teacher",

                   NormalizedName = "teacher",

                   ConcurrencyStamp = Guid.NewGuid().ToString(),

               }
                );
        }

      

    }
}
