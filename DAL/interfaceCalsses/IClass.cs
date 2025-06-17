using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public  interface IClass
    {
        // evlement crud in there
        public List<clsClass> GetClassList();
    }
}
