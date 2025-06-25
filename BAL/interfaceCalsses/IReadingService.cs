using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.interfaceCalsses
{
    public interface IReadingService
    {
        GlobalVar._SaveMode SaveMode { get; set; }
        clsReading Reading {  get; set; }
        List<clsReadingDay> GetAllReadingDays();
        clsReadingDay GetReadingDayByID(int id);
        List<clsReadingDay> GetReadingDaysByDate(DateTime date);
        int CreateReadingDay(clsReadingDay entity);
        bool UpdateReadingDay(clsReadingDay entity);
        bool DeleteReadingDay(int id);
        clsReadingDay GetLastReadingDay();

        // ----- Readings -----
        List<clsReading> GetReadingsByDayID(int readingDayID);
        List<clsReading> GetReadingsByQuranStudentID(int quranStudentID);
        clsReading GetReadingByID(int id);
        int CreateReading(clsReading entity);
        bool UpdateReading(clsReading entity);
        bool DeleteReading(int id);
    }
}
