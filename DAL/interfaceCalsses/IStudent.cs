using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IStudent
    {
        public int Add(clsStudent student);
        public bool Update(clsStudent student);
        public bool Delete(int StudentID);
        public clsStudent GetByStudentID(int StudentID);
        public clsStudent GetByPersonID(int PersonID);
        public List<clsStudent> GetList();// Use StudentFiter And return Data Using clsStudentTableView
        public bool IsExist(int StudentID);
        public bool IsStudent(int PersonID); // And Declare This Func In IPerson
        public bool IsUniqueStudent(int PersonID, int StudentID);
        public List<clsStudentTableView> GetStudentTableView(clsStudentFilter filter);
        public List<SqlParameter> HandleSqlStudentTvfPrameters(clsStudentFilter filter,ref IPerson person );

        public List<SqlParameter> GetSqlStudentTvfPrameters(clsStudentFilter Filter);
        public List<SqlParameter> GetSqlEnrollmentTvfPrameters(clsEnrollmentStudentInClassFilter Filter);
        public int EnrollStudentInCourse(int  StudentID,int CourseID);
        public bool EnrollStudentInCourse(clsEnrolmentStudentInClass EnrolmentStudent);
        public clsEnrolmentStudentInClass GetEnrolmentStudentInClass(int EnrollmentStudentID);
        public List<clsEnrolmentStudentInClass> GetActiveEnrollmenstStudent(int studentID);
        public clsEnrolmentStudentInClass GetActiveEnrollmentStudent(int studentID,int ClassID);
        public bool HasStudentActiveEnrollment(int studentID, int ClassID);
        public string GetEnrollmentTabelViewQuery();
    
    }
}
