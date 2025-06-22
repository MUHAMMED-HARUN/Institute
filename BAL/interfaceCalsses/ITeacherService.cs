using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System.Collections.Generic;
using static BAL.GlobalVar;

namespace BAL.interfaceCalsses
{
    public interface ITeacherService
    {
        clsTeacher Teacher { get; set; }
        clsEnrolmentTeacherInClass EnrolmentTeacher { get; set; }
       // clsTeacherTableView TeacherTableView { get; set; }
        _SaveMode SaveMode { get; set; }
        bool Add();
        bool Update();
        clsTeacher GetByID(int TeacherID);
        clsTeacher GetByPersonID(int PersonID);
        public List<clsTeacherTableView> GetAll(clsTeacherFilter filter);
        bool IsExist(int TeacherID);
        bool IsTeacher(int PersonID);
        bool IsUniqueTeacher(int PersonID, int TeacherID);
        bool Save();
        bool Delete(int TeacherID);
        public List<clsEnrollmentTeacherInClassTableView> GetEnrollmentList(clsEnrolmentTeacherInClassFilter filter);
        public bool HasActiveEnrollmentTeacher(int TeacherID, int ClassID);
        public clsEnrolmentTeacherInClass GetEnrolmentTeacherInClass(int EnrollmentTeacherID);
        public Dictionary<string, int> GetEnrollmentStatusList();
        public bool EnrollTeacherInClass(clsEnrolmentTeacherInClass Enrol);
        public bool HandleEnrollmentTeacher();

        //List<clsTeacherTableView> GetTeacherTableView(clsTeacherFilter filter);
    }
}
