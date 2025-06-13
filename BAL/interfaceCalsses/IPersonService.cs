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
    public interface IPersonService
    {
        GlobalVar._SaveMode SaveMode { get; set; }
        public clsPerson Person{ get; set; }
        public  clsAddress Address{ get; set; }
        public int Add(clsPerson person ,clsAddress address);
        public bool Update(clsPerson person,clsAddress address) ;
        public bool Save();
        public bool Delete(int PersonID);
        public clsPerson GetByID(int PersonID);
        public clsPerson GetByNationalNumber(string NationalNumber);
        public List<clsPerson> GetList();
        public Dictionary<string, int> RelationshipStatusArabic();
        public bool IsNationalNumberUnique(string NationalNumber,int PersonID=-1);
        public List<clsPersonTableView> GetPersonTableView(clsPersonFilter Filter);
        public bool IsExist(int PersonID);
    }
}
