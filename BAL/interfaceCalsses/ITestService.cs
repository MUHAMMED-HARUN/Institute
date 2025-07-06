using BAL.ViewModel;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BAL.interfaceCalsses
{
    public interface ITestService
    {
        public GlobalVar._SaveMode SaveMode { get; set; }
       public clsNomination Nomination { get; set; }
        public clsQuranTest QuranTest { get; set; }
         // Basic Test
        public List<clsBasicTestInfo> GetBasicTestInfos();


        // Nomination
        public clsNomination GetNomination(int NominationID);
        public bool NominateForTesting(clsNomination nomination);
        public bool UpdateNominate(clsNomination nomination);
        public List<clsNominationTableView> GetNominationList(clsFilterNomination filter);
        public bool SaveNominate();
        // Quran Test
        public clsQuranTest GetQuranTest(int QTestID);
        public bool TestQuranStudent(clsQuranTest quranTest);
        public bool UpdateQuranStudentTest(clsQuranTest quranTest);
        public bool SaveQuranTest();
        public List<clsQuranTestViewModel> GetQuranStudentTests(clsQuranTestFilter filter);
    }
}
