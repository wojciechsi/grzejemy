namespace grzejemy.Models
{
    public class Buyer : User
    {
        public Buyer() : base()
        {
            favouriteFuel = new FuelType();
        }

        private FuelType favouriteFuel { get; set; } 
    }
}
