namespace grzejemy.Server.Models
{
    public class Offer
    {
        public Offer() 
        {
            FuelType = new FuelType("groszek");
        }
        public int Id { get; set; }

        public FuelType FuelType { get; set; }

        public float Price { get; set; }
    }
}
