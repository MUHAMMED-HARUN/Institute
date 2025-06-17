using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.interfaceCalsses
{
    public interface IClassService
    {
        public List<clsClass> GetClassList();
    }
}
