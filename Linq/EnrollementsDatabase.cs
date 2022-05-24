namespace LWAJWTLOG.Linq
{
    public class EnrollementsDatabase
    {
        public static IEnumerable<Enrollments> GetEnrollmentsData()
        {
            return new List<Enrollments>
            {
                new Enrollments(01, "Full stack course",1000 ,"Deepak Mishra"),
                new Enrollments(02, "Web Development",10000 ,"Raj"),

            };
        }
    }
}
