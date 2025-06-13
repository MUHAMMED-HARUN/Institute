using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IStudent
    {
        public int Add(clsStudent student);
        public bool Update(clsStudent student);
        public bool Delete(int StudentID);
        public clsStudent GetByStudentID(int StudentID);
        public clsStudent GetByPersonID(int PersonID);
        public List<clsStudent> GetList();// Use StudentFiter And return Data Using clsStudentTableView
        public bool IsExist(int StudentID);
        public bool IsStudent(int PersonID); // And Declare This Func In IPerson
        public bool IsUniqueStudent(int PersonID, int StudentID);
        public List<clsStudentTableView> GetStudentTableView(clsStudentFilter filter);
        public object[] HandleSqlStudentTvfPrameters(clsStudentFilter filter);
        public object[] GetSqlStudentTvfPrameters(clsStudentFilter Filter);
    }
}
