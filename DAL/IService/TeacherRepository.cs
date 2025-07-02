using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

namespace DAL.Classes
{
    public class TeacherRepository : ITeacher
    {
        AppDBContext _Context;
        IServiceProvider _serviceProvider;
        public TeacherRepository(AppDBContext context,IServiceProvider serviceProvider)
        {
            _Context = context;
            _serviceProvider = serviceProvider;
        }
        public bool Add(clsTeacher teacher)
        {
            _Context.Add(teacher);
            return _Context.SaveChanges() > 0;
        }

        public bool Update(clsTeacher teacher)
        {
            _Context.Update(teacher);
            return _Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.ID == id);
            if (teacher != null)
            {
                _Context.Remove(teacher);
                return _Context.SaveChanges() > 0;
            }
            return false;
        }

        public clsTeacher GetByID(int id)
        {
            clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.ID == id);
            return teacher;
        }

        public clsTeacher GetByPersonID(int personID)
        {
            clsTeacher teacher = _Context.clsTeacher.FirstOrDefault(t => t.PersonID == personID);
            return teacher;
        }

        public List<clsTeacher> GetAll()
        {
            return null;
        }

        public bool IsExist(int id)
        {
            return _Context.clsTeacher.Any(t => t.PersonID == id);

        }

        public bool IsUniqueTeacher(int personID, int teacherID)
        {
            // تحقق من عدم تكرار الربط بين person والمعلم (عدا نفسه عند التعديل)
            return true;
        }

        public bool IsTeacher(int personID)
        {
            return _Context.clsTeacher.Any(t => t.PersonID == personID);
        }
        public string GetSqlTeacherTvfQuiery()
        {
            return @"@TeacherID, @EntryDate, @ExitDate, @IsActive";
        }
        public List<SqlParameter> GetSqlTeacherTvfPrameters(clsTeacherFilter Filter)
        {
            List<SqlParameter> prams = new List<SqlParameter>
                {
                    new SqlParameter("@TeacherID", Filter.TeacherID ?? (object)DBNull.Value),
                    new SqlParameter("@EntryDate", Filter.EntryDate == DateTime.MinValue ? new DateTime(1900, 01, 01) : Filter.EntryDate),
                    new SqlParameter("@ExitDate",   Filter.ExitDate == DateTime.MinValue ? new DateTime(DateTime.MaxValue.Ticks) : Filter.ExitDate),
                    new SqlParameter("@IsActive", Filter.IsActive ?? (object)DBNull.Value),
            };
            return prams;
        }
        public List<SqlParameter> HandleSqlTeacherTvfPrameters(clsTeacherFilter filter, ref IPerson person)
        {
            if (person == null)
                return null;

            List<SqlParameter> Prams = GetSqlTeacherTvfPrameters(filter).Concat(person.GetSqlPersonTvfPrameters(filter)).ToList();
            return Prams;
        }
        public List<clsTeacherTableView> GetTeacherTableView(clsTeacherFilter filter)
        {
            IPerson person = (IPerson)_serviceProvider.GetService(typeof(IPerson));
            if (person == null)
                return null;

            string SqlTeacherTVF = @"SELECT * FROM [dbo].[ufn_FilterTeacher] (" +
                                    GetSqlTeacherTvfQuiery() + "," +
                                    person.GetSqlPersonTvfQuiery() + ")";

            using (var connection = _Context.Database.GetDbConnection().CreateCommand())
            {
                connection.CommandText = SqlTeacherTVF;
                connection.CommandType = System.Data.CommandType.Text;

                if (connection.Connection.State != System.Data.ConnectionState.Open)
                    connection.Connection.Open();

                List<SqlParameter> prameters = HandleSqlTeacherTvfPrameters(filter, ref person);
                foreach (var prameter in prameters)
                {
                    connection.Parameters.Add(prameter);
                }

                List<clsTeacherTableView> Result = new List<clsTeacherTableView>();

                using (var reader = connection.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsTeacherTableView Teacher = new clsTeacherTableView
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
                            TeacherID = reader["TeacherID"] as int?, // نستخدم StudentID لأن الـ TVF يرجع العمود بهذا الاسم في SQL
                            IsActiveText = reader["IsActive"] as string,
                            EntryDate = reader["EntryDate"] as DateTime?,
                            ExitDate = reader["ExitDate"] as DateTime?
                        };
                        Result.Add(Teacher);
                    }
                }

                return Result;
            }
        }

        public bool EnrollTeacherInClass(clsEnrolmentTeacherInClass Enrol)
        {
            _Context.EnrolmentTeachers.Add(Enrol);
            return _Context.SaveChanges() > 0;
        }
        public bool HasTeacherActiveEnrollment(int teacherID, int classID)
        {
            using (DbCommand command = _Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT dbo.ufn_HasTeachertActiveEnrollment(@TeacherID, @ClassID)";
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter("@TeacherID", teacherID));
                command.Parameters.Add(new SqlParameter("@ClassID", classID));

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                var result = command.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                    return false;

                return Convert.ToBoolean(result);
            }
        }
        public clsEnrolmentTeacherInClass GetEnrolmentTeacherInClass(int EnrollmentTeacherID)
        {
            return _Context.EnrolmentTeachers.FirstOrDefault(e => e.ID == EnrollmentTeacherID);
        }
        public List<SqlParameter> GetSqlEnrollmentTeacherTvfPrameters(clsEnrolmentTeacherInClassFilter filter)
        {
            List<SqlParameter> prams = new List<SqlParameter>()
    {
        new SqlParameter("@TeacherID", filter.TeacherID ?? (object)DBNull.Value),
        new SqlParameter("@NationalNumber", filter.NationalNumber ?? (object)DBNull.Value),
        new SqlParameter("@TeacherFullName", filter.TeacherFullName ?? (object)DBNull.Value),
        new SqlParameter("@ClassID", filter.ClassID ?? (object)DBNull.Value),
        new SqlParameter("@ClassName", filter.ClassName ?? (object)DBNull.Value),
        new SqlParameter("@IsActive", filter.IsActive ?? (object)DBNull.Value),
    };
            return prams;
        }
        public string GetEnrollmentTeacherTableViewQuery()
        {
            return "SELECT * FROM dbo.ufn_GetEnrollmentTeacherClass(@TeacherID, @NationalNumber, @TeacherFullName, @ClassID, @ClassName, @IsActive)";
        }
        public List<clsEnrollmentTeacherInClassTableView> GetEnrollmentTeacherTableView(clsEnrolmentTeacherInClassFilter filter)
        {
            using (DbCommand command = _Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = GetEnrollmentTeacherTableViewQuery() ;
                command.CommandType = CommandType.Text;

                List<SqlParameter> prams = GetSqlEnrollmentTeacherTvfPrameters(filter);
                foreach (var param in prams)
                {
                    command.Parameters.Add(param);
                }

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                List<clsEnrollmentTeacherInClassTableView> result = new();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsEnrollmentTeacherInClassTableView enrollment = new clsEnrollmentTeacherInClassTableView
                        {
                            ID = Convert.ToInt32(reader["ID"]),
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
