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
        //List<clsTeacherTableView> GetTeacherTableView(clsTeacherFilter filter);
    }
}
