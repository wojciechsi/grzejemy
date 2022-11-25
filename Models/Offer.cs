namespace grzejemy.Models
{
    public class Offer
    {
        public Offer() 
        {
            FuelType = new FuelType();
        }
        public int Id { get; set; }

        public FuelType FuelType { get; set; }

        public float Price { get; set; }
    }
}
