using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
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
            return  _Context.Database.ExecuteSqlRaw("exec DeletePerson @PersonID = {0}", PersonID)>0;
            
        }

        public bool EditPerson(clsPerson ToEditPerson,clsAddress address)
        {
            clsPerson p = GetPersonByID(ToEditPerson.PersonID);
            address.ID= p.AddressID;
            _Context.Update(address);
            ToEditPerson.AddressID = address.ID;
            clsPerson? local= _Context.Set<clsPerson>().Local.FirstOrDefault(entry=>entry.PersonID==ToEditPerson.PersonID);
           
            if (local != null)
            {
                _Context.Entry(local).State = EntityState.Detached;
            }

            _Context.Attach(ToEditPerson);
            _Context.Entry(ToEditPerson).State = EntityState.Modified;

            return _Context.SaveChanges() > 0;
        }
        public clsPerson GetPersonByID(int PersonID)
        {
            return _Context.People.AsNoTracking().FirstOrDefault(p => p.PersonID == PersonID);
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
            if (PersonID == -1)
                return !_Context.People.Any(p => p.NationalNumber == NationalNumber);
            else
                return !_Context.People.Any(p => p.NationalNumber == NationalNumber && p.PersonID != PersonID);
        }

        public object[] GetSqlPersonTvfPrameters(clsPersonFilter Filter)
        {
            object[] prams = { new SqlParameter("@PersonID", Filter.PersonID ?? (object)DBNull.Value),
                new SqlParameter("@NationalNumber", Filter.NationalNumber ?? (object)DBNull.Value),
                new SqlParameter("@FirstName", Filter.FirstName ?? (object)DBNull.Value),
                new SqlParameter("@FatherName", Filter.FatherName ?? (object)DBNull.Value),
                new SqlParameter("@LastName", Filter.LastName ?? (object)DBNull.Value),
                new SqlParameter("@FullName", Filter.FullName ?? (object)DBNull.Value),
                new SqlParameter("@MotherName", Filter.MotherName ?? (object)DBNull.Value),
                new SqlParameter("@MotherLastName", Filter.MotherLastName ?? (object)DBNull.Value),
                new SqlParameter("@PhoneNumber", Filter.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@MinDate", Filter.MinDate ?? new DateTime(1900, 01, 01)),
                new SqlParameter("@MaxDate", Filter.MaxDate ?? new DateTime(DateTime.Now.Ticks)),
                new SqlParameter("@Gendor", Filter.Gendor ?? (object)DBNull.Value),
                new SqlParameter("@PersonalStatus", Filter.PersonalStatus ?? (object)DBNull.Value),
                new SqlParameter("@Country", Filter.Country ?? (object)DBNull.Value),
                new SqlParameter("@City", Filter.City ?? (object)DBNull.Value),
                new SqlParameter("@District", Filter.District ?? (object)DBNull.Value),
                new SqlParameter("@Neighborhood", Filter.Neighborhood ?? (object)DBNull.Value)};
            return prams;
        }
        public string GetSqlPersonTvfQuiery()
        {
             return @"@PersonID, @NationalNumber, @FirstName, @FatherName, @LastName,
             @FullName, @MotherName, @MotherLastName, @PhoneNumber, @MinDate,
             @MaxDate, @Gendor, @PersonalStatus, @Country, @City, @District, @Neighborhood"; 
        } 
        public List<clsPersonTableView> GetPersonTableView(clsPersonFilter Filter)
        {
            string SqlPersonTVF = @"SELECT * FROM [dbo].[ufn_FilterPersons] (" + GetSqlPersonTvfQuiery()+")";
         List<clsPersonTableView> PersonView=   _Context.PersonTableView.FromSqlRaw(SqlPersonTVF,GetSqlPersonTvfPrameters(Filter)).ToList();
            return PersonView;
        }
    }
}
