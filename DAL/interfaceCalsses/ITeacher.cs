using DAL.Models;
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
    }
}
