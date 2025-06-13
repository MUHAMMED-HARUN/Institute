using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.interfaceCalsses
{
   public interface IStudentService
    {
        GlobalVar._SaveMode SaveMode { get; set; }
        public clsPerson Person { get; set; }
        public clsStudent Student {  get; set; }
        public int Add(clsStudent student);
        public bool Update(clsStudent student);
        public bool Save();
        public bool Delete(int StudentID);
        public clsStudent GetByStudentID(int StudentID);
        public clsStudent GetByPersonID(int PersonID);
        public List<clsStudent> GetList();
        public List<clsStudentTableView> GetList(clsStudentFilter filter);// Use StudentFiter And return Data Using clsStudentTableView
        public bool IsExist(int StudentID);
        public bool IsStudent(int PersonID); // And Declare This Func In IPerson
        public bool IsUniqueStudent(int PersonID,int StudentID);
    }
}
