using BAL.interfaceCalsses;
using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class QuranStudentService : IQuranStudentService
    {
        private readonly IQuranStudent _quranStudentRepo;
        public GlobalVar._SaveMode SaveMode { get; set; }
        public virtual clsQuranStudent QuranStudent { get; set; }

        public QuranStudentService(IQuranStudent quranStudentRepo)
        {
            _quranStudentRepo = quranStudentRepo;
        }

    

        public bool Delete(int id)
        {
            return _quranStudentRepo.Delete(id);
        }

        public clsQuranStudent GetByID(int id)
        {
            return _quranStudentRepo.GetByID(id);
        }

        public List<clsQuranStudent> GetAll()
        {
            return _quranStudentRepo.GetAll();
        }

        public bool IsExist(int id)
        {
            return _quranStudentRepo.IsExist(id);
        }

        public bool IsQuranStudent(int baseStudentID)
        {
            return _quranStudentRepo.IsQuranStudent(baseStudentID);
        }

        public bool Add(clsQuranStudent entity)
        {
           return _quranStudentRepo.Add(entity);
        }

        public bool Update(clsQuranStudent entity)
        {
            return _quranStudentRepo.Update(entity);
        }
        public bool IsAlreadyInProject(int ProjectID, int BaseStudentID)
        {
            return _quranStudentRepo.IsAlreadyInProject(ProjectID, BaseStudentID);
        }
        public bool Save()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                if (Add(QuranStudent))
                {
                    SaveMode = GlobalVar._SaveMode.Update;
                    return true;
                }
            }
            else
            {
                return Update(QuranStudent);
            }
            return false;
        }
    }
}

