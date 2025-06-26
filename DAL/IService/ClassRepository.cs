using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class ClassRepository : IClass
    {
        AppDBContext _Context;
        public ClassRepository(AppDBContext dBContext)
        {
            _Context = dBContext;
        }
        public clsClass GetByID(int ClassID)
        {
            return _Context.Classes.AsNoTracking().Where(C => C.ID == ClassID).FirstOrDefault(); 
        }
        public List<clsClass> GetClassList()
        {
            return _Context.Classes.ToList();
        }
    }
}
