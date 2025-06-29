using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class ReadingRepository:IReading
    {
        private readonly AppDBContext _context;

        public ReadingRepository(AppDBContext context)
        {
            _context = context;
        }

        // ---------------- Reading Day ----------------
        public List<clsReadingDay> GetAllReadingDays()
        {
            return _context.ReadingDay.ToList();
        }

        public clsReadingDay GetReadingDayByID(int id)
        {
            return _context.ReadingDay.Find(id);
        }

        public List<clsReadingDay> GetReadingDaysByDate(DateTime date)
        {
            return _context.ReadingDay
                           .Where(d => d.ReadingDate.Date == date.Date)
                           .ToList();
        }

        public int AddReadingDay(clsReadingDay entity)
        {
            _context.ReadingDay.Add(entity);
            _context.SaveChanges();
            return entity.ID;
        }

        public bool UpdateReadingDay(clsReadingDay entity)
        {
            _context.ReadingDay.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteReadingDay(int id)
        {
            var entity = _context.ReadingDay.Find(id);
            if (entity == null) return false;

            _context.ReadingDay.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<clsReadingDay> GetReadingDaysByQuranStudentID(int quranStudentID)
        {
            throw new NotImplementedException();
        }

        public clsReadingDay GetLastReadingDay()
        {
            return _context.ReadingDay.OrderByDescending(r => r.ID).FirstOrDefault();
        }

        // ---------------- Reading ----------------
        public List<clsReading> GetReadingsByDayID(int readingDayID)
        {
            //return _context.Readings
            //               .Where(r => r.ReadingDayID == readingDayID)
            //               .Include(r => r.QuranStudent)
            //               .Include(r=>r.ReadingDay)
            //               .ToList();
            return _context.Readings
    .Where(r => r.ReadingDayID == readingDayID)
    .Select(r => new clsReading
    {
        QuranStudentID=r.QuranStudentID,
        ID = r.ID,
        ReadedPageNum=r.ReadedPageNum,
        PerformanceRating=r.PerformanceRating,
        ReadigType=r.ReadigType,
        ReadingDay = r.ReadingDay,
        QuranStudent = new clsQuranStudent
        {
            ID = r.QuranStudent.ID,
            student = new clsStudent
            {
                ID = r.QuranStudent.student.ID,
                Person = new clsPerson
                {
                    PersonID = r.QuranStudent.student.Person.PersonID,
                    FirstName = r.QuranStudent.student.Person.FirstName,
                    FatherName = r.QuranStudent.student.Person.FatherName,
                    LastName = r.QuranStudent.student.Person.LastName
                }
            }
        }
    })
    .ToList();
        }

        public List<clsReading> GetReadingsByQuranStudentID(int quranStudentID)
        {
            return _context.Readings
                           .Where(r => r.QuranStudentID == quranStudentID)
                           .Include(r => r.ReadingDay)
                           .ToList();

        }

        public clsReading GetReadingByID(int id)
        {
            return _context.Readings. Where(r => r.ID == id)
                .Include(r => r.QuranStudent)
                .Include(r => r.ReadingDay)
                .FirstOrDefault(r => r.ID == id);

        }
    
        public int AddReading(clsReading entity)
        {
            _context.Readings.Add(entity);
            _context.SaveChanges();
            return entity.ID;
        }

        public bool UpdateReading(clsReading entity)
        {
            _context.Readings.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteReading(int id)
        {
            var entity = _context.Readings.Find(id);
            if (entity == null) return false;

            _context.Readings.Remove(entity);
            return _context.SaveChanges() > 0;
        }

		public short GetLastReadedPageNum(int QuranStudent)
        {
            clsReading reading = _context.Readings.Where(r => r.QuranStudentID == QuranStudent&&(r.PerformanceRating!=1 && r.ReadigType!=2) ).OrderByDescending(r => r.ReadingDayID).FirstOrDefault();
            if (reading == null)
                return 604 +1;

            return reading.ReadedPageNum;
        }
	}
}
