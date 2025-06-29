namespace BAL
{
    public class GlobalVar
    {
        public enum enRelationshipStatus
        {
            Single,     // أعزب
            Married,    // متزوج
            Divorced,   // مطلق
            Orphan      // يتيم
        }
      
        public enum _SaveMode
        {
            Update,New
        }
      

        public enum EnrollmentStatus
        {
            Completed = 1, Expired, NotCompleted, Cancelled
        }
        public enum PerformanceRating
        {
            Poor = 1,
            Acceptable,
            Good,
            VeryGood,
            Excellent
        }
        static public Dictionary<string, byte> GetPerformanceRating()
        {
            Dictionary<string, byte> Dict = new Dictionary<string, byte>();
            Dict.Add("ضعيف", 1);
            Dict.Add("مقبول", 2);
            Dict.Add("جيد", 3);
            Dict.Add("جيد جدا", 4);
            Dict.Add("ممتاز", 5);
            return Dict;
        }
        static public string  GetPerformanceRating(byte PerformanceR)
        {

            switch (PerformanceR)
            {
                case 1:
                    return "ضعيف";
                case 2:
                    return "مقبول";
                case 3:
                    return "جيد";
                case 4:
                    return "جيد جدا";
                case 5:
                    return "ممتاز";
            }
            return "ضعيف";
        }

        public enum ReadingType
        {
            New = 1, Review
        }
        static public Dictionary<string, byte> GetReadingType()
        {
            Dictionary<string, byte> Dict = new Dictionary<string, byte>();
            Dict.Add("جديد", 1);
            Dict.Add("مراجعة", 2);
         
            return Dict;
        }
        static public string GetReadingType(byte ReadingType)
        {
            switch (ReadingType)
            {
                case (int)GlobalVar.ReadingType.New:
                    return "جديد";
                case (int)GlobalVar.ReadingType.Review:
                    return "مراجعة";
              
            }
            return "جديد";
        }
        public enum Departments
        {
            QuranDept= 1,
        }
    }
}
