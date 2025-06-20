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
        public virtual clsEnrolmentStudentInClass EnrolmentStudentInClass { get; set; }
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
        public bool EnrollStudentInClass(clsEnrolmentStudentInClass EnrolmentStudent)
        {
            return _StudentRepository.EnrollStudentInCourse(EnrolmentStudent);
        }
        public bool HandleEnrollmentStudent()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                // New EnrollMent
                if (!EnrollStudentInClass(EnrolmentStudentInClass))
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
        public clsEnrolmentStudentInClass GetEnrolmentStudentInClass(int EnrollmentStudentID)
        {
            return _StudentRepository.GetEnrolmentStudentInClass(EnrollmentStudentID);
        }
        public List<clsEnrolmentStudentInClass> GetActiveEnrollmenstStudent(int studentID)
        {
           return _StudentRepository.GetActiveEnrollmenstStudent(studentID);
        }
        public clsEnrolmentStudentInClass GetActiveEnrollmentStudent(int studentID, int ClassID)
        {
            return _StudentRepository.GetActiveEnrollmentStudent(studentID, ClassID);
        }
        public Dictionary<string, int> GetEnrollmentStatusList()
        {
            
            Dictionary<string,int> EnrollStatus = new Dictionary<string, int>();
            EnrollStatus.Add("مكتمل", 1);
            EnrollStatus.Add("منتهي", 2);
            EnrollStatus.Add("ليس مكتمل", 3);
            EnrollStatus.Add("ملغي", 4);
            return EnrollStatus;
        }
        public bool HasActiveEnrollment(int StudentID, int ClassID)
        {
            return _StudentRepository.HasStudentActiveEnrollment(StudentID, ClassID);
        }
        public List<clsEnrollmentStudentInClassTableView> GetEnrollmentTableView(clsEnrollmentStudentInClassFilter Filter)
        {
            return _StudentRepository.GetEnrollmentTableView(Filter);
        }
    }
}
