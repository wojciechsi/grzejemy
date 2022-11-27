namespace grzejemy.Models
{
    public class Offer
    {
        public Offer() 
        {
            FuelType = new FuelType();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public FuelType FuelType { get; set; }
        public float Price { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}
