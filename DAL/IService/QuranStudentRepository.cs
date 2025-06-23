using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            _context= context;
        }
        public bool Add(clsQuranStudent entity)
        {
           _context.Add(entity);
            return _context.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            clsQuranStudent quranStudent=  _context.QuranStudents.FirstOrDefault(q => q.ID == id); 
            if (quranStudent==null)
                return false;
            _context.Remove(quranStudent);
            return _context.SaveChanges() > 0;
        }

        public List<clsQuranStudent> GetAll()
        {
            throw new NotImplementedException();
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
            return _context.QuranStudents.Any(q=>q.StudentID == BaseStudentID);
        }

        public bool Update(clsQuranStudent entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
        public bool IsAlreadyInProject( int ProjectID, int BaseStudentID)
        {
            return _context.QuranStudents.Any(q => q.StudentID == BaseStudentID &&
            q.ProjectID == ProjectID);
        }
    }
}
