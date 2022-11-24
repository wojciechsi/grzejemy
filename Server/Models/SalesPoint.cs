namespace grzejemy.Server.Models
{
    struct Address
    {
        public string Street;
        public string Number;
        public string PostCode;
        public string City;
    }


    public class SalesPoint
    {
        public SalesPoint()
        {
            Offers = new List<Offer>();
            Address = new Address();
        }

        private int? Id { get; set; }
        private string Name { get; set; }
        private Address Address { get; set; }
        private List<Offer> Offers { get; set; }

    }
}
