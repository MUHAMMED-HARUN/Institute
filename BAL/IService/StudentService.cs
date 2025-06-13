using BAL.interfaceCalsses;
using DAL.interfaceCalsses;
using DAL.IService;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class StudentService : IStudentService
    {
        public GlobalVar._SaveMode SaveMode {  get; set; }
        public virtual clsPerson Person {get; set; }
        public virtual clsStudent Student { get; set; }
        IStudent _StudentRepository;
        public StudentService(IStudent studentRepository)
        {
            _StudentRepository = studentRepository;
        }
        public int Add(clsStudent student)
        {
            return _StudentRepository.Add(student);
        }

        public bool Delete(int StudentID)
        {
           return  _StudentRepository.Delete(StudentID);
        }

        public clsStudent GetByPersonID(int PersonID)
        {
          return  _StudentRepository.GetByPersonID(PersonID);
        }

        public clsStudent GetByStudentID(int StudentID)
        {
            return _StudentRepository.GetByStudentID(StudentID);
        }

        public List<clsStudent> GetList()
        {
            return _StudentRepository.GetList();
        }

        public bool IsExist(int StudentID)
        {
            return _StudentRepository.IsExist(StudentID);
        }

        public bool IsStudent(int PersonID)
        {
            return _StudentRepository.IsStudent(PersonID);
        }

        public bool Update(clsStudent student)
        {
            return _StudentRepository.Update(student);
        }
		public bool Save()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                if (Add(this.Student) > 0)
                {
                    SaveMode = GlobalVar._SaveMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return Update(this.Student);
            }
            
        }
        public bool IsUniqueStudent(int PersonID, int StudentID)
        {
         return   _StudentRepository.IsUniqueStudent(PersonID, StudentID);
        }
        public List<clsStudentTableView> GetList(clsStudentFilter filter)
        {
            return _StudentRepository.GetStudentTableView(filter);
        }
    }
}
