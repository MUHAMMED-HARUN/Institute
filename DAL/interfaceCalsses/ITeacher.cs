using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.interfaceCalsses
{
    public interface ITeacher
    {
        bool Add(clsTeacher teacher);
        bool Update(clsTeacher teacher);
        bool Delete(int id);
        clsTeacher GetByID(int id);
        clsTeacher GetByPersonID(int personID);
        List<clsTeacher> GetAll();
        bool IsExist(int id);
        bool IsUniqueTeacher(int personID, int teacherID);
        bool IsTeacher(int personID);
        public bool EnrollTeacherInClass(clsEnrolmentTeacherInClass Enrol);

      
        public List<clsTeacherTableView> GetTeacherTableView(clsTeacherFilter filter);
        public List<SqlParameter> HandleSqlTeacherTvfPrameters(clsTeacherFilter filter, ref IPerson person);
        public List<SqlParameter> GetSqlTeacherTvfPrameters(clsTeacherFilter Filter);
        public List<clsEnrollmentTeacherInClassTableView> GetEnrollmentTeacherTableView(clsEnrolmentTeacherInClassFilter filter);
        public string GetEnrollmentTeacherTableViewQuery();
        public List<SqlParameter> GetSqlEnrollmentTeacherTvfPrameters(clsEnrolmentTeacherInClassFilter filter);
        public bool HasTeacherActiveEnrollment(int teacherID, int classID);
        public clsEnrolmentTeacherInClass GetEnrolmentTeacherInClass(int EnrollmentTeacherID);

    }
}
