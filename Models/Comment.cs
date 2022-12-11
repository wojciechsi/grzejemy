using Microsoft.AspNetCore.Identity;
namespace grzejemy.Models
{
    public class Comment
    {
        public Comment() 
        {
            Verified = false;
            Author = new IdentityUser();
            Offer = new Offer();
        }
        public int Id { get; set; }
        public IdentityUser Author { get; set; }
        public Offer Offer { get; set; }
        public float PaidPrice { get; set; }
        public string? Content { get; set; }
        public bool Verified { get; set; }
        public int? ParagonId { get; set; }
        public int? QualityGrade { get; set; }
        public string? QualityComment { get; set; }
    }
}
