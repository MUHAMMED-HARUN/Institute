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
    public class ReadingService : IReadingService
    {
        IReading _readingRepo;

        public GlobalVar._SaveMode SaveMode { get; set; }
        public virtual clsReading Reading { get; set; }
        public virtual clsReadingDay ReadingDay { get; set; }
        public ReadingService(IReading reading)
        {
            _readingRepo = reading;
        }
        // ---------------- Reading Days ----------------
        public List<clsReadingDay> GetAllReadingDays()
        {
            return _readingRepo.GetAllReadingDays();
        }

        public clsReadingDay GetReadingDayByID(int id)
        {
            return _readingRepo.GetReadingDayByID(id);
        }

        public List<clsReadingDay> GetReadingDaysByDate(DateTime date)
        {
            return _readingRepo.GetReadingDaysByDate(date);
        }

        public int CreateReadingDay(clsReadingDay entity)
        {
            return _readingRepo.AddReadingDay(entity);
        }

        public bool UpdateReadingDay(clsReadingDay entity)
        {
            throw new Exception();
        }

        public bool DeleteReadingDay(int id)
        {
            return _readingRepo.DeleteReadingDay(id);
        }
        public clsReadingDay GetLastReadingDay()
        {
            return _readingRepo.GetLastReadingDay();
        }

        // ---------------- Readings ----------------
        public List<clsReading> GetReadingsByDayID(int readingDayID)
        {
            return _readingRepo.GetReadingsByDayID(readingDayID);
        }

        public List<clsReading> GetReadingsByQuranStudentID(int quranStudentID)
        {
            return _readingRepo.GetReadingsByQuranStudentID(quranStudentID);
        }

        public clsReading GetReadingByID(int id)
        {
            return _readingRepo.GetReadingByID(id);
        }

        public int CreateReading(clsReading entity)
        {
            return _readingRepo.AddReading(entity);
        }

        public bool UpdateReading(clsReading entity)
        {
            return _readingRepo.UpdateReading(entity);
        }

        public bool DeleteReading(int id)
        {
            return _readingRepo.DeleteReading(id);
        }
        public bool SaveReading()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
            {
                if (CreateReading(Reading) > 0)
                {
                    SaveMode = GlobalVar._SaveMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                return UpdateReading(Reading);
            }
        }
        public short GetLastForReadingPageNum(int QuranStudent)
        {
            short LastReadedPageNumber= _readingRepo.GetLastReadedPageNum(QuranStudent);
            short ToReadPage = 0;

			if (LastReadedPageNumber > 582)
			{
				return (short)(LastReadedPageNumber - 1);
			}
			else if (LastReadedPageNumber == 582)
				return 562; //return

			else if (LastReadedPageNumber < 581)
			{
				return (short)(LastReadedPageNumber + 1);
			}
			else if (LastReadedPageNumber == 581)
			{
				return 1; // return;
			}
			else
				return (short)(LastReadedPageNumber + 1);
		}

        public short GetLastReadedPageNum(int QuranStudent)
        {
            short lastPagerReaded = _readingRepo.GetLastReadedPageNum(QuranStudent);

            return lastPagerReaded;
        }
	}
}
