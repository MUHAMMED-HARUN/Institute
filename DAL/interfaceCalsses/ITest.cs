using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface ITest
    {
        // Basic Test
        public List<clsBasicTestInfo> GetBasicTestInfos();


        // Nomination
        public clsNomination GetNomination(int NominationID);
        public bool NominateForTesting(clsNomination nomination);
        public bool UpdateNominate(clsNomination nomination);
        public List<clsNominationTableView> GetNominationList(clsFilterNomination filter);

        // Quran Test
        public clsQuranTest GetQuranTest(int QTestID);
        public bool TestQuranStudent(clsQuranTest quranTest);
        public bool UpdateQuranStudentTest (clsQuranTest quranTest);
        public List<clsQuranTestViewModel> GetQuranStudentTests(clsQuranTestFilter filter);
    }
}
