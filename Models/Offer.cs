namespace grzejemy.Models
{
    public class Offer
    {
        public Offer() 
        {
            Comments = new List<Comment>();
            SalesPoint = new SalesPoint();
            FuelType= new FuelType();
        }
        public int Id { get; set; }
       
        public float Price { get; set; }
        public List<Comment> Comments { get; set; } 
        public SalesPoint SalesPoint { get; set; }
        public FuelType FuelType { get; set; }
    }
}
