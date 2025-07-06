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
using System.Data;
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
        public clsBasicTestInfo GetBasicTestInfo(int BasicTestID)
        {
            return _Context.BasicTestInfos.Where(b => b.ID == BasicTestID).FirstOrDefault();
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
                            TestName = reader["TestName"] as string,
                            FromPart = reader["FromPart"] as byte?,
                            ToPart = reader["ToPart"] as byte?

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
        public bool HasActiveQuranTsetNomination(int QSID, int BTestID)
        {
            return _Context.Nominations
                .Any(n => n.QuranStudentID == QSID && n.BasicTestID == BTestID && n.TestStatus == 2);// Test Waiting
        }
        // Quran Test
        public clsQuranTest GetQuranTest(int QTestID)
        {
            return _Context.QuranTests.AsNoTracking().Where(qt => qt.ID == QTestID).FirstOrDefault();
        }
        public bool TestQuranStudent(clsQuranTest quranTest)
        {
            _Context.QuranTests.Add(quranTest);
            return _Context.SaveChanges() > 0;
        }
        public bool UpdateQuranStudentTest(clsQuranTest quranTest)
        {
            return true;
        }
        public List<clsQuranTestViewModel> GetFilteredQuranTests(clsQuranTestFilter filter)
        {
            using (var command = _Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
            SELECT * FROM dbo.ufn_FilterQuranTests
            (@NominationID, @CommitteeName, @StartGrade, @EndGrade, @FromPart, @ToPart, @QSName)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@NominationID", filter.NominationID ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@CommitteeName", filter.CommitteeName ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@StartGrade", filter.StartGrade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@EndGrade", filter.EndGrade ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FromPart", filter.FromPart ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@ToPart", filter.ToPart ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@QSName", filter.QSName ?? (object)DBNull.Value));

                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                var result = new List<clsQuranTestViewModel>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new clsQuranTestViewModel
                        {
                            QSTestID = reader.GetInt32(0),
                            CommitteeID = reader.GetInt32(1),
                            CommitteeName = reader.GetString(2),
                            Grade = reader.GetInt16(3),
                            NominationID = reader.GetInt32(4),
                            QSID = reader.GetInt32(5),
                            QSName = reader.GetString(6),
                            FromPart = reader.IsDBNull(7) ? null : (byte?)reader.GetByte(7),
                            ToPart = reader.IsDBNull(8) ? null : (byte?)reader.GetByte(8),
                        });
                    }
                }

                return result;
            }
        }

        public List<clsQuranTestViewModel> GetQuranStudentTests(clsQuranTestFilter filter)
        {

            return GetFilteredQuranTests(filter);
        }
    }
}
