using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class QuranStudentRepository : IQuranStudent
    {
        AppDBContext _context;
        public QuranStudentRepository(AppDBContext context)
        {
            _context = context;
        }
        public bool Add(clsQuranStudent entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }  

        public bool Delete(int id)
        {
            clsQuranStudent quranStudent = _context.QuranStudents.FirstOrDefault(q => q.ID == id);
            if (quranStudent == null)
                return false;
            _context.Remove(quranStudent);
            return _context.SaveChanges() > 0;
        }

        public List<clsQuranStudentTableView> GetAll(clsQuranStudentFilter filter)
        {
           return GetQuranStudentTableView(filter);
        }

        public clsQuranStudent GetByID(int id)
        {
            return _context.QuranStudents.AsNoTracking().FirstOrDefault(q => q.ID == id);
        }

        public bool IsExist(int ID)
        {
            return _context.QuranStudents.Any(q => q.ID == ID);
        }

        public bool IsQuranStudent(int BaseStudentID)
        {
            return _context.QuranStudents.Any(q => q.StudentID == BaseStudentID);
        }

        public bool Update(clsQuranStudent entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
        public bool IsAlreadyInProject(int ProjectID, int BaseStudentID)
        {
            return _context.QuranStudents.Any(q => q.StudentID == BaseStudentID &&
            q.ProjectID == ProjectID);
        }
        string GetQuranStudentTVFQuery()
        {
            return "SELECT * FROM dbo.ufn_FilterQuranStudent(" +
                   "@QuranStudentID, @StartSevdPage, @EndSevdPage, @StartInstalledPart, @EndInstalledPart, @ProjectID, @PerformanceRating," +
                   "@StudentID, @EntryDate, @ExitDate, @IsActive," +
                   "@PersonID, @NationalNumber, @FirstName, @FatherName, @LastName, @FullName, @MotherName, @MotherLastName, @PhoneNumber," +
                   "@MinDate, @MaxDate, @Gendor, @PersonalStatus, @Country, @City, @District, @Neighborhood)";
        }

         List<SqlParameter> GetSqlQuranStudentTVFParameters(clsQuranStudentFilter filter)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@QuranStudentID", filter.QuranStudentID ?? (object)DBNull.Value),
                new SqlParameter("@StartSevdPage", filter.StartSevdPage ?? (object)DBNull.Value),
                new SqlParameter("@EndSevdPage", filter.EndSevdPage ?? (object)DBNull.Value),
                new SqlParameter("@StartInstalledPart", filter.StartInstalledPart ?? (object)DBNull.Value),
                new SqlParameter("@EndInstalledPart", filter.EndInstalledPart ?? (object)DBNull.Value),
                new SqlParameter("@ProjectID", filter.ProjectID ?? (object)DBNull.Value),
                new SqlParameter("@PerformanceRating", filter.PerformanceRating ?? (object)DBNull.Value),

                new SqlParameter("@StudentID", filter.StudentID ?? (object)DBNull.Value),
                new SqlParameter("@EntryDate", filter.EntryDate ?? new DateTime(1900, 01, 01)),
                new SqlParameter("@ExitDate", filter.ExitDate ?? new DateTime(9999, 12, 31)),
                new SqlParameter("@IsActive", filter.IsActive ?? (object)DBNull.Value),

                new SqlParameter("@PersonID", filter.PersonID ?? (object)DBNull.Value),
                new SqlParameter("@NationalNumber", filter.NationalNumber ?? (object)DBNull.Value),
                new SqlParameter("@FirstName", filter.FirstName ?? (object)DBNull.Value),
                new SqlParameter("@FatherName", filter.FatherName ?? (object)DBNull.Value),
                new SqlParameter("@LastName", filter.LastName ?? (object)DBNull.Value),
                new SqlParameter("@FullName", filter.FullName ?? (object)DBNull.Value),
                new SqlParameter("@MotherName", filter.MotherName ?? (object)DBNull.Value),
                new SqlParameter("@MotherLastName", filter.MotherLastName ?? (object)DBNull.Value),
                new SqlParameter("@PhoneNumber", filter.PhoneNumber ?? (object)DBNull.Value),
                new SqlParameter("@MinDate", filter.MinDate ?? new DateTime(1900, 01, 01)),
                new SqlParameter("@MaxDate", filter.MaxDate ?? new DateTime(9999, 12, 31)),
                new SqlParameter("@Gendor", filter.Gendor ?? (object)DBNull.Value),
                new SqlParameter("@PersonalStatus", filter.PersonalStatus ?? (object)DBNull.Value),
                new SqlParameter("@Country", filter.Country ?? (object)DBNull.Value),
                new SqlParameter("@City", filter.City ?? (object)DBNull.Value),
                new SqlParameter("@District", filter.District ?? (object)DBNull.Value),
                new SqlParameter("@Neighborhood", filter.Neighborhood ?? (object)DBNull.Value),
            };
        }

         List<clsQuranStudentTableView> GetQuranStudentTableView(clsQuranStudentFilter filter)
        {
            using (DbCommand command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = GetQuranStudentTVFQuery();
                command.CommandType = CommandType.Text;

                foreach (var param in GetSqlQuranStudentTVFParameters(filter))
                {
                    command.Parameters.Add(param);
                }

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                List<clsQuranStudentTableView> result = new List<clsQuranStudentTableView>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsQuranStudentTableView item = new clsQuranStudentTableView
                        {
                            QuranStudentID = Convert.ToInt32(reader["QuranStudentID"]),
                            TotalSavedPages = Convert.ToInt16(reader["TotalSavedPages"]),
                            TotalInstalledParts = Convert.ToByte(reader["TotalInstalledParts"]),
                            ProjectName = reader["ProjectName"] as string,
                            PerformanceRatingText = reader["PerformanceRatingText"] as string,
                            StudentID = reader["StudentID"] as int?,
                            PersonID = reader["PersonID"] as int?,
                            NationalNumber = reader["NationalNumber"] as string,
                            FullName = reader["FullName"] as string,
                            PhoneNumber = reader["PhoneNumber"] as string,
                            GendorText = reader["GendorText"] as string,
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
                            IsActive = reader["IsActive"] as string,
                            EntryDate = reader["EntryDate"] as DateTime?,
                            ExitDate = reader["ExitDate"] as DateTime?
                        };
                        result.Add(item);
                    }
                }

                return result;
            }
        }
    }
}