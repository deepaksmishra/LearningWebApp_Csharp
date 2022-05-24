namespace LWAJWTLOG.Linq
{
    public class Enrollments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Seller { get; set; }

        public Enrollments(int id, string Name, int price, string seller)
        {
            id = id;
            Name = Name;
            price = price;
            seller = seller;
        }
    }
}
