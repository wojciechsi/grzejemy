namespace grzejemy.Models
{
    /*
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public Address()
        {
            Street = string.Empty;
            Number = string.Empty;
            PostCode = string.Empty;
            City = string.Empty;
        }


    }
    */

    public class SalesPoint
    {

        public SalesPoint()
        {
            Offers = new List<Offer>();
            Vendor = new User();
            Name = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            PostCode = string.Empty;
            City = string.Empty;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<Offer> Offers { get; set; }
        public User Vendor { get; set; }

    }
}
