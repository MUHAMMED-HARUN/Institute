namespace ViewModel
{
    public class GenericVar
    {
        public enum MaritalStatus
        {
            Single = 0,
            Married = 1,
            Divorced = 2,
            Widowed = 3,
            Other = 4
        }

        public enum EnrollmentStatus
        {
            Completed=1, Expired, NotCompleted, Cancelled
        } 
        public enum PerformanceRating
        {
            Poor=1,
            Acceptable,
            Good,
            VeryGood,
            Excellent
        }
        static public Dictionary<string ,int > GetPerformanceRating()
        {
            Dictionary<string,int> Dict = new Dictionary<string ,int>();
            Dict.Add("ضعيف", 1);
            Dict.Add("مقبول", 2);
            Dict.Add("جيد", 3);
            Dict.Add("جيد جدا", 4);
            Dict.Add("ممتاز",5);
            return Dict; 
        }
        public enum ReadingType
        {
            New=1,Review
        }
    }
}
