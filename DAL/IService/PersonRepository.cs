using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class PersonRepository : IPerson
    {
        AppDBContext _Context;
        public PersonRepository(AppDBContext dBContext)
        {
            _Context = dBContext;
        }
        public int AddNewPerson(clsPerson NewPerson ,clsAddress address)
        {
            using (IDbContextTransaction transaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    // 1. إضافة العنوان
                    _Context.Add(address);
                    _Context.SaveChanges();

                    // 2. تعيين معرف العنوان للشخص
                    NewPerson.AddressID = address.ID;

                    // 3. إضافة الشخص
                    _Context.Add(NewPerson);
                    _Context.SaveChanges();

                    // 4. تأكيد العملية
                    transaction.Commit();
                    return NewPerson.PersonID;
                }
                catch
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public bool DeletePerson(int PersonID)
        {
            //_Context.People.Remove(new clsPerson());
            // change field Person.isdeleted to true;
            return false;
        }

        public bool EditPerson(clsPerson ToEditPerson,clsAddress address)
        {
            _Context.Update(address);
           _Context.Update(ToEditPerson);
            return _Context.SaveChanges() > 0;
        }
        public clsPerson GetPersonByID(int PersonID)
        {
            return _Context.People.FirstOrDefault(p => p.PersonID == PersonID);
        }

        public clsPerson GetPersonByNationalNumber(string NationalNumber)
        {
            return _Context.People.FirstOrDefault(p => p.NationalNumber == NationalNumber);

        }

        public List<clsPerson> GetPersonList()
        {
            return _Context.People.ToList();
        }
        public bool IsNationalNumberUnique(string NationalNumber, int PersonID = -1)
        {
            if (PersonID != -1)
                return !_Context.People.Any(p => p.NationalNumber == NationalNumber);
            else
                return !_Context.People.Any(p => p.NationalNumber == NationalNumber && p.PersonID != PersonID);
        }
   
    }
}
