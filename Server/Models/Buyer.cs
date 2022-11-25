namespace grzejemy.Server.Models
{
    public class Buyer : User
    {
        public Buyer() : base()
        {
            //favouriteFuel = new FuelType("groszek");
        }

        private FuelType favouriteFuel { get; set; } 
    }
}
