using BAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using DAL.interfaceCalsses;
using System.Collections.Generic;
using static BAL.GlobalVar;

namespace BAL.Classes
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacher _teacherRepo;

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
    }
}
