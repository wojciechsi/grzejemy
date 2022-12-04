namespace grzejemy.Models
{
    public class Offer
    {
        public Offer() 
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public int FuelTypeId { get; set; }
        public float Price { get; set; }
        public List<Comment> Comments { get; set; } 
        public int SalesPointId { get; set; }
    }
}
