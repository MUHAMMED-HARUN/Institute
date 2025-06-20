using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public List<SqlParameter> GetSqlStudentTvfPrameters(clsStudentFilter Filter)
        {
            List<SqlParameter> prams = new List<SqlParameter>{
                new SqlParameter("@StudentID", Filter.StudentID ?? (object)DBNull.Value),
                new SqlParameter("@EntryDate", Filter.EntryDate ?? new DateTime(1900, 01, 01)),
                new SqlParameter("@ExitDate",   Filter.ExitDate ?? new DateTime(DateTime.MaxValue.Ticks)),
                new SqlParameter("@IsActive",Filter.IsActive ?? (object)DBNull.Value),
            };
            return prams;
        }
        public List<SqlParameter> HandleSqlStudentTvfPrameters(clsStudentFilter filter, ref IPerson person)
        {
            if (person == null)
                return null;
            List<SqlParameter> Prams = GetSqlStudentTvfPrameters(filter).Concat(person.GetSqlPersonTvfPrameters(filter)).ToList();

            return Prams;
        }
        public List<clsStudentTableView> GetStudentTableView(clsStudentFilter filter)
        {


            IPerson person = (IPerson)_serviceProvider.GetService(typeof(IPerson));
            if (person == null)
                return null;
            string SqlStudentTVF = @"SELECT * FROM [dbo].[ufn_FilterStudent] ("
            + GetSqlStudentTvfQuiery() + "," + person.GetSqlPersonTvfQuiery() + ")";

            using (var connection = _Context.Database.GetDbConnection().CreateCommand())
            {
                connection.CommandText = SqlStudentTVF;
                connection.CommandType = System.Data.CommandType.Text;

                if (connection.Connection.State != System.Data.ConnectionState.Open)
                    connection.Connection.Open();
                List<SqlParameter> prameters = HandleSqlStudentTvfPrameters(filter, ref person);
                foreach (var prameter in prameters)
                {
                    connection.Parameters.Add(prameter);
                }
                List<clsStudentTableView> Result = new List<clsStudentTableView>();

                using (var reader = connection.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsStudentTableView Student = new clsStudentTableView
                        {

                            PersonID = reader["PersonID"] as int?,
                            NationalNumber = reader["NationalNumber"] as string,
                            FirstName = reader["FirstName"] as string,
                            FatherName = reader["FatherName"] as string,
                            GrandFatherName = reader["GrandFatherName"] as string,
                            LastName = reader["LastName"] as string,
                            FullName = reader["FullName"] as string,
                            MotherName = reader["MotherName"] as string,
                            MotherLastName = reader["MotherLastName"] as string,
                            MotherFullName = reader["MotherFullName"] as string,
                            GendorText = reader["GendorText"] as string,
                            PhoneNumber = reader["PhoneNumber"] as string,
                            CountryName = reader["CountryName"] as string,
                            AddressCityName = reader["AddressCityName"] as string,
                            DistrictName = reader["DistrictName"] as string,
                            NeighborhoodName = reader["NeighborhoodName"] as string,
                            AddressDetails = reader["AddressDetails"] as string,
                            PlaceOfBirthName = reader["PlaceOfBirthName"] as string,
                            BirthDate = reader["BirthDate"] as DateTime?,
                            PersonalStatus = reader["PersonalStatus"] as string,
                            Image = reader["Image"] as string,
                            NationalIDImage = reader["NationalIDImage"] as string,
                            StudentID = reader["StudentID"] as int?,
                            IsActive = reader["IsActive"] as string,
                            EntryDate = reader["EntryDate"] as DateTime?,
                            ExitDate = reader["ExitDate"] as DateTime?
                        };
                        Result.Add(Student);
                    }
                }
                return Result;
            }

        }
        //public int EnrollStudentInCourse(clsEnrolmentStudentInClass enrolmentStudentInClass)
        //{
        //    _Context.EnrolmentStudent.Add(enrolmentStudentInClass);\
        //    return 1;
        //}

        public int EnrollStudentInCourse(int StudentID, int CourseID)
        {
            throw new NotImplementedException();
        }
        public bool EnrollStudentInCourse(clsEnrolmentStudentInClass EnrolmentStudent)
        {
            _Context.EnrolmentStudent.Add(EnrolmentStudent);
            return _Context.SaveChanges() > 0;
        }
        public clsEnrolmentStudentInClass GetEnrolmentStudentInClass(int EnrollmentStudentID)
        {
            return _Context.EnrolmentStudent.FirstOrDefault(e => e.ID == EnrollmentStudentID);
        }
        public List<clsEnrolmentStudentInClass> GetActiveEnrollmenstStudent(int studentID)
        {
            throw null;
        }
        public clsEnrolmentStudentInClass GetActiveEnrollmentStudent(int studentID, int ClassID)
        {
            throw null;
        }
        public bool HasStudentActiveEnrollment(int studentID, int ClassID)
        {
            using (DbCommand command = _Context.Database.GetDbConnection().CreateCommand())
            {
                bool HasActive;
                command.CommandText = "HasStudentActiveEnrollment @StudentID=@studentid,@ClassID=@classid,@IsActive=@isactive OUTPUT";
                command.Parameters.Add(new SqlParameter("@studentid", studentID));
                command.Parameters.Add(new SqlParameter("@classid", ClassID));
                SqlParameter OutPutPram = new SqlParameter("@isactive", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(OutPutPram);

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();
                command.ExecuteScalar();

                if (OutPutPram.Value == DBNull.Value)
                    return false;

                HasActive = Convert.ToBoolean(OutPutPram.Value);
                return HasActive;
            }
        }
        public List<SqlParameter> GetSqlEnrollmentTvfPrameters(clsEnrollmentStudentInClassFilter Filter)
        {
            List<SqlParameter> prams = new List<SqlParameter>() {
            new SqlParameter("@StudentID",Filter.StudentID??(object)DBNull.Value),
            new SqlParameter("@NationalNumber",Filter.NationalNumber??(object)DBNull.Value),
            new SqlParameter("@StudentFullName",Filter.StudentFullName??(object)DBNull.Value),
            new SqlParameter("@ClassID",Filter.CalssID??(object)DBNull.Value),
            new SqlParameter("@ClassName",Filter.ClassName??(object)DBNull.Value),
            new SqlParameter("@IsActive",Filter.IsActive??(object)DBNull.Value),

            };
            return prams;
        }
        public string GetEnrollmentTabelViewQuery()
        {
            string Query = "SELECT * FROM dbo.ufn_GetEnrollmentStudentClass(@StudentID, @NationalNumber, @StudentFullName, @ClassID, @ClassName, @IsActive)";
            return Query;
        }
        public List<clsEnrollmentStudentInClassTableView> GetEnrollmentTableView(clsEnrollmentStudentInClassFilter Filter)
        {
            using(DbCommand command = _Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = GetEnrollmentTabelViewQuery();
                command.CommandType = CommandType.Text;
                List<SqlParameter> prams =GetSqlEnrollmentTvfPrameters(Filter);
                for(int i = 0; i < prams.Count; i++)
                {
                    command.Parameters.Add(prams[i]);
                }

                if(command.Connection.State!=ConnectionState.Open)
                    command.Connection.Open();

                List<clsEnrollmentStudentInClassTableView> result =new List<clsEnrollmentStudentInClassTableView> ();

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        clsEnrollmentStudentInClassTableView enrollment = new clsEnrollmentStudentInClassTableView
                        {
                            ID = reader["ID"] as int?,
                            FullName = reader["FullName"] as string,
                            NationalNumber = reader["NationalNumber"] as string,
                            ClassName = reader["ClassName"] as string,
                            IsActive = reader["IsActive"] as string
                        };
                        result.Add(enrollment);
                    }
                }
                return result;
            }
        }

    }
}
