using BAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using DAL.interfaceCalsses;
using System.Collections.Generic;
using static BAL.GlobalVar;
using DAL.IService;

namespace BAL.Classes
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacher _teacherRepo;
       public virtual clsEnrolmentTeacherInClass EnrolmentTeacher { get; set; }
        public TeacherService(ITeacher teacherDAL)
        {
            _teacherRepo = teacherDAL;
        }

        public virtual clsTeacher Teacher { get; set; }
      //  public clsTeacherTableView TeacherTableView { get; set; }
        public _SaveMode SaveMode { get; set; }

        public bool Delete(int TeacherID)
        {
            return _teacherRepo.Delete(TeacherID);
        }

        public clsTeacher GetByID(int TeacherID)
        {
            return _teacherRepo.GetByID(TeacherID);
        }

        public clsTeacher GetByPersonID(int PersonID)
        {
            return _teacherRepo.GetByPersonID(PersonID);
        }

        public List<clsTeacherTableView> GetAll(clsTeacherFilter filter)
        {
            return _teacherRepo.GetTeacherTableView(filter);
        }

        public bool IsExist(int TeacherID)
        {
            return _teacherRepo.IsExist(TeacherID);
        }

        public bool IsTeacher(int PersonID)
        {
            return _teacherRepo.IsTeacher(PersonID);
        }

        public bool IsUniqueTeacher(int PersonID, int TeacherID)
        {
            return _teacherRepo.IsUniqueTeacher(PersonID, TeacherID);
        }

        public bool Save()
        {
            if (SaveMode == _SaveMode.New)
            {
                if (Add())
                {
                    this.SaveMode = _SaveMode.Update;
                    return true;
                }
            }
                
            else
                return Update();

            return false;
        }

        //public List<clsTeacherTableView> GetTeacherTableView(clsTeacherFilter filter)
        //{
        //    return _teacherRepo.GetTeacherTableView(filter);
        //}

        public bool Add()
        {
            return _teacherRepo.Add(Teacher);
        }

        public bool Update()
        {
           return _teacherRepo.Update(Teacher);
        }
        public bool HasActiveEnrollmentTeacher(int TeacherID,int ClassID)
        {
            return _teacherRepo.HasTeacherActiveEnrollment(TeacherID, ClassID);
        }
        public List<clsEnrollmentTeacherInClassTableView> GetEnrollmentList(clsEnrolmentTeacherInClassFilter filter)
        {
            return _teacherRepo.GetEnrollmentTeacherTableView(filter);
        }
        public clsEnrolmentTeacherInClass GetEnrolmentTeacherInClass(int EnrollmentTeacherID)
        {
            return _teacherRepo.GetEnrolmentTeacherInClass(EnrollmentTeacherID);
        }

        public bool EnrollTeacherInClass(clsEnrolmentTeacherInClass Enrol)
        {
          return  _teacherRepo.EnrollTeacherInClass(Enrol);
        }
        public bool HandleEnrollmentTeacher()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                // New EnrollMent
                if (!EnrollTeacherInClass(EnrolmentTeacher))
                    return false;
                SaveMode = GlobalVar._SaveMode.Update;
                return true;

            }
            else
            {
                // Updete Enrollment
                return false;
            }
        }
        public Dictionary<string, int> GetEnrollmentStatusList()
        {

            Dictionary<string, int> EnrollStatus = new Dictionary<string, int>();
            EnrollStatus.Add("مكتمل", 1);
            EnrollStatus.Add("منتهي", 2);
            EnrollStatus.Add("ليس مكتمل", 3);
            EnrollStatus.Add("ملغي", 4);
            return EnrollStatus;
        }
    }
}
