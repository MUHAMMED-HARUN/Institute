using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DAL.IService
{
    public class TestRepository : ITest
    {
        AppDBContext _Context;
        public TestRepository(AppDBContext context)
        {
            _Context = context;
        }

        // Basic Test
        public List<clsBasicTestInfo> GetBasicTestInfos()
        {
            return _Context.BasicTestInfos.ToList();
        }


        // Nomination

        public clsNomination GetNomination(int NominationID)
        {
            return _Context.Nominations.AsNoTracking().Where(n => n.ID == NominationID).FirstOrDefault();
        }
        public bool NominateForTesting(clsNomination nomination)
        {
            _Context.Nominations.Add(nomination);
            return _Context.SaveChanges() > 0;
        }
        public bool UpdateNominate(clsNomination nomination)
        {
            _Context.Update(nomination);
            return _Context.SaveChanges() > 0;
        }
        public string GetSqlNominationTvfQuiery()
        {
            return @"@FullName, @StartTestDate,@EndTestDate";
        }
        public List<SqlParameter> GetSqlNominationTvfPrameters(clsFilterNomination Filter)
        {
            List<SqlParameter> prams = new List<SqlParameter>
           {
               new SqlParameter("@FullName", Filter.FullName ?? (object)DBNull.Value),
               new SqlParameter("@StartTestDate", Filter.StartTestDate == DateTime.MinValue ? new DateTime(1900, 01, 01) : Filter.StartTestDate),
               new SqlParameter("@EndTestDate",   Filter.EndTestDate == DateTime.MinValue ? new DateTime(DateTime.MaxValue.Ticks) : Filter.EndTestDate),

       };
            return prams;
        }
        List<clsNominationTableView> GetNominationTableView(clsFilterNomination filter)
        {

            string SqlTeacherTVF = @"SELECT * FROM [dbo].[ufn_FilterNomination]  (" +
                                    GetSqlNominationTvfQuiery() + ")";

            using (var connection = _Context.Database.GetDbConnection().CreateCommand())
            {
                connection.CommandText = SqlTeacherTVF;
                connection.CommandType = System.Data.CommandType.Text;

                if (connection.Connection.State != System.Data.ConnectionState.Open)
                    connection.Connection.Open();

                List<SqlParameter> prameters = GetSqlNominationTvfPrameters(filter);
                foreach (var prameter in prameters)
                {
                    connection.Parameters.Add(prameter);
                }

                List<clsNominationTableView> Result = new List<clsNominationTableView>();

                using (var reader = connection.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsNominationTableView Nomination = new clsNominationTableView
                        {
                            NominationID = reader["NominationID"] as int?,
                            QuranStudentID = reader["QuranStudentID"] as int?,
                            QuranStudentFullName = reader["QuranStudentFullName"] as string,
                            NominationDate = reader["NominationDate"] as DateTime?,
                            BasicTestID = reader["BasicTestID"] as int?,
                            TestDate = reader["TestDate"] as DateTime?,
                            TestName = reader["TestName"] as string
                        };
                        Result.Add(Nomination);
                    }
                }

                return Result;
            }
        }
        public List<clsNominationTableView> GetNominationList(clsFilterNomination filter)
        {
            return GetNominationTableView(filter);
        }

        // Quran Test
        public bool TestQuranStudent(clsQuranTest quranTest)
        {
            _Context.QuranTests.Add(quranTest);
            return _Context.SaveChanges() > 0;
        }
        public bool UpdateQuranStudentTest(clsQuranTest quranTest)
        {
            return true;
        }
        public List<clsQuranTestViewModel> GetQuranStudentTests()
        {
            return _Context.QuranTests.Select(qt => new clsQuranTestViewModel
            {
                QSTestID = qt.ID,
                CommitteeID = qt.CommitteeID,
                CommitteeName = qt.Committee.GroupName,
                Grade = qt.Grade,
                NominationID = qt.NominationID,
                QSID = qt.Nomination.QuranStudentID,
                QSName = qt.Nomination.QuranStudent.student.Person.FirstName
            }).ToList();
        }
    }
}
