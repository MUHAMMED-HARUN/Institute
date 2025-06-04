using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IPerson
    {
        public int AddNewPerson(clsPerson NewPerson, clsAddress address);
        public bool EditPerson(clsPerson ToEditPerson,clsAddress address);
        public clsPerson GetPersonByID(int PersonID);
        public clsPerson GetPersonByNationalNumber(string NationalNumber);
        public List<clsPerson> GetPersonList();
        bool DeletePerson(int PersonID);
        public bool IsNationalNumberUnique(string NationalNumber, int PersonID = -1);
       
    }
}
