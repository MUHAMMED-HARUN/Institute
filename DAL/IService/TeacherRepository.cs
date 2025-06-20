using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using System.Collections.Generic;

namespace DAL.Classes
{
    public class TeacherRepository : ITeacher
    {
        AppDBContext _Context;
        public TeacherRepository(AppDBContext context)
        {
            _Context = context;  
        }
        public bool Add(clsTeacher teacher)
        {
                _Context.Add(teacher);
            return _Context.SaveChanges() > 0;
        }

        public bool Update(clsTeacher teacher)
        {
_Context.Update(teacher);
            return _Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.ID == id);
            if (teacher != null)
            {
                _Context.Remove(teacher);
                return _Context.SaveChanges() > 0;
            }
            return false;
        }

        public clsTeacher GetByID(int id)
        {
            clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.ID == id);
            return teacher;
        }

        public clsTeacher GetByPersonID(int personID)
        {
                        clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.PersonID == personID);
            return teacher;
        }

        public List<clsTeacher> GetAll()
        {
            return new List<clsTeacher>
            {
                new clsTeacher { ID = 1, PersonID = 10, EntryDate = DateTime.Now, IsActive = true },
                new clsTeacher { ID = 2, PersonID = 11, EntryDate = DateTime.Now.AddMonths(-5), IsActive = false }
            };
        }

        public bool IsExist(int id)
        {
            return _Context.clsTeacher.Any(t => t.PersonID == id);

        }

        public bool IsUniqueTeacher(int personID, int teacherID)
        {
            // تحقق من عدم تكرار الربط بين person والمعلم (عدا نفسه عند التعديل)
            return true;
        }

        public bool IsTeacher(int personID)
        {
            return _Context.clsTeacher.Any(t=>t.PersonID == personID);
        }
    }
}
