using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IReading
    {
        // ReadingDay
        List<clsReadingDay> GetAllReadingDays();
        clsReadingDay GetReadingDayByID(int id);
        List<clsReadingDay> GetReadingDaysByQuranStudentID(int quranStudentID);
        int AddReadingDay(clsReadingDay entity);
        bool DeleteReadingDay(int id);
        public List<clsReadingDay> GetReadingDaysByDate(DateTime date);

        clsReadingDay GetLastReadingDay();
        // Reading
        List<clsReading> GetReadingsByDayID(int readingDayID);
        clsReading GetReadingByID(int id);
        int AddReading(clsReading entity);
        bool UpdateReading(clsReading entity);
        bool DeleteReading(int id);
        public List<clsReading> GetReadingsByQuranStudentID(int quranStudentID);

    }
}
