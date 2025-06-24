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
    public interface IQuranStudent
    {
        public clsQuranStudent GetByID(int id);
        public bool IsExist(int ID);
        public bool IsQuranStudent(int BaseStudentID);
        public bool Add(clsQuranStudent entity);
        public bool Update(clsQuranStudent entity);
        public bool Delete(int id);
        public bool IsAlreadyInProject( int ProjectID, int BaseStudentID);
        public List<clsQuranStudentTableView> GetAll(clsQuranStudentFilter filter);
    }
}
