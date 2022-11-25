namespace grzejemy.Models
{
    public class Buyer : User
    {
        public Buyer() : base()
        {
            favouriteFuel = new FuelType();
        }

        public FuelType favouriteFuel { get; set; } 
    }
}
