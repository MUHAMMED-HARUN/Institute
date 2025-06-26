using BAL.interfaceCalsses;
using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class ClassService : IClassService
    {
        IClass _ClassRepo;
        public ClassService(IClass ClassRepo)
        {
            _ClassRepo = ClassRepo;
        }

        public clsClass GetByID(int ClassID)
        {
            throw new NotImplementedException();
        }

        public List<clsClass> GetClassList()
        {
          return  _ClassRepo.GetClassList();
        }
    }
}
