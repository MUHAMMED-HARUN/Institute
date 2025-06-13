using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class StudentRepository : IStudent
    {
        AppDBContext _Context;
        IServiceProvider _serviceProvider;
        public StudentRepository(AppDBContext dBContext, IServiceProvider serviceProvider)
        {
            _Context = dBContext;
            this._serviceProvider = serviceProvider;
        }
        public int Add(clsStudent student)
        {
            _Context.Students.Add(student);

            return (_Context.SaveChanges() > 0) ? student.ID : -1;
        }
        public bool Update(clsStudent student)
        {
            _Context.Students.Update(student);
            return (_Context.SaveChanges() > 0) ? true : false;
        }
        public bool Delete(int StudentID)
        {
            clsStudent student = GetByStudentID(StudentID);
            if (student == null)
                return false;
            _Context.Students.Remove(student);
            return _Context.SaveChanges() > 0;
        }
        public clsStudent GetByStudentID(int StudentID)
        {
            return _Context.Students.AsNoTracking().FirstOrDefault(s => s.ID == StudentID);
        }
        public clsStudent GetByPersonID(int PersonID)
        {
            return _Context.Students.AsNoTracking().FirstOrDefault(s => s.PersonID == PersonID);
        }
        public List<clsStudent> GetList()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int StudentID)
        {
            return _Context.Students.Any(s => s.ID == StudentID);
        }

        public bool IsStudent(int PersonID)
        {
            return (_Context.Students.Any(s => s.PersonID == PersonID));
        }

        public bool IsUniqueStudent(int PersonID, int StudentID)
        {

            return !_Context.Students.Any(s => s.PersonID == PersonID && s.ID != StudentID);
        }

        public string GetSqlStudentTvfQuiery()
        {
            return @"@StudentID, @EntryDate, @ExitDate, @IsActive";
        }

        public object[] GetSqlStudentTvfPrameters(clsStudentFilter Filter)
        {
            object[] prams = {
                new SqlParameter("@StudentID", Filter.StudentID ?? (object)DBNull.Value),
                new SqlParameter("@EntryDate", Filter.EntryDate ?? new DateTime(1900, 01, 01)),
                new SqlParameter("@ExitDate",   Filter.ExitDate ?? new DateTime(DateTime.MaxValue.Ticks)),
                new SqlParameter("@IsActive",Filter.IsActive ?? (object)DBNull.Value),
            };
            return prams;
        }
        public object[] HandleSqlStudentTvfPrameters(clsStudentFilter filter)
        {
            IPerson person = (IPerson)_serviceProvider.GetService(typeof(IPerson));
            object[] Prams = GetSqlStudentTvfPrameters(filter).Concat(person.GetSqlPersonTvfPrameters(filter)).ToArray();

            string s ="";
            foreach (SqlParameter pram in Prams) 
            {
                s += pram.ToString() + "=" + pram.SqlValue ?? "null";
               //if( pram.va)
            }
            return Prams;
        }
        public List<clsStudentTableView> GetStudentTableView(clsStudentFilter filter)
        {
            
            IPerson person = (IPerson)_serviceProvider.GetService(typeof(IPerson));
            string SqlStudentTVF = @"SELECT * FROM [dbo].[ufn_FilterStudent] ("
            + GetSqlStudentTvfQuiery() + "," + person.GetSqlPersonTvfQuiery() + ")";

            List<clsStudentTableView> StudentTable = _Context.StudentTableView.
                FromSqlRaw(SqlStudentTVF, HandleSqlStudentTvfPrameters(filter)).ToList();
            return StudentTable;
        }
    }
}
