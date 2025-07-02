using BAL.interfaceCalsses;
using BAL.ViewModel;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BAL.IService
{
    public class TestService : ITestService
    {
        ITest _TestRepo;
        public GlobalVar._SaveMode SaveMode { get; set; }
        public virtual clsNomination Nomination { get; set; }
        public TestService(ITest test)
        {
            _TestRepo = test;
        }

        // Basic Test
        public List<clsBasicTestInfo> GetBasicTestInfos()
        {
            return _TestRepo.GetBasicTestInfos();
        }


        // Nomination
        public clsNomination GetNomination(int NominationID)
        {
           return _TestRepo.GetNomination(NominationID);
        }
        public bool NominateForTesting(clsNomination nomination)
        {
          return  _TestRepo.NominateForTesting(nomination);
        }
        public bool UpdateNominate(clsNomination nomination)
        {
          return  _TestRepo.UpdateNominate(nomination);
        }
        public List<clsNominationTableView> GetNominationList(clsFilterNomination filter)
        {
            return _TestRepo.GetNominationList(filter);
        }

        public bool SaveNominate()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                if (_TestRepo.NominateForTesting(Nomination))
                {
                    SaveMode = GlobalVar._SaveMode.Update;
                    return true;
                }
            }
            else
            {
                return _TestRepo.UpdateNominate(Nomination);
            }
            return false;
        }
        // Quran Test
        public bool TestQuranStudent(clsQuranTest quranTest)
        {
          return  _TestRepo.TestQuranStudent(quranTest);
        }
        public bool UpdateQuranStudentTest(clsQuranTest quranTest)
        {
            return _TestRepo.UpdateQuranStudentTest(quranTest);
        }
        public List<clsQuranTestViewModel> GetQuranStudentTests()
        {
            return _TestRepo.GetQuranStudentTests();
        }
    }
}
