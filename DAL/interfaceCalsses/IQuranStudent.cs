using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IQuranStudent
    {
        public List<clsQuranStudent> GetAll();
        public clsQuranStudent GetByID(int id);
        public bool IsExist(int ID);
        public bool IsQuranStudent(int BaseStudentID);
        public bool Add(clsQuranStudent entity);
        public bool Update(clsQuranStudent entity);
        public bool Delete(int id);
        public bool IsAlreadyInProject( int ProjectID, int BaseStudentID);
    }
}
