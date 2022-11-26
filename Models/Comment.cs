using Microsoft.AspNetCore.Identity;
namespace grzejemy.Models
{
    public class Comment
    {
        Comment() 
        {
            Verified = false;
            Author = new IdentityUser();
        }
        public int Id { get; set; }
        public IdentityUser Author { get; set; }
        public float PaidPrice { get; set; }
        public string? Content { get; set; }
        public bool Verified { get; set; }
        public int? ParagonId { get; set; }
        public int? QualityGrade { get; set; }
        public string? QualityComment { get; set; }
    }
}
