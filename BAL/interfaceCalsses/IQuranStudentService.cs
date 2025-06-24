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
    public interface IQuranStudentService
    {
        public GlobalVar._SaveMode SaveMode { get; set; }
        public clsQuranStudent QuranStudent { get; set; }
         bool Add(clsQuranStudent entity);
         bool Update(clsQuranStudent entity);
        public bool Delete(int id);
        public clsQuranStudent GetByID(int id);
        public List<clsQuranStudentTableView> GetAll(clsQuranStudentFilter filter);
        public bool IsExist(int id);
        public bool IsQuranStudent(int baseStudentID);
        public bool IsAlreadyInProject(int ProjectID, int BaseStudentID);
        public bool Save();
    }
}
