namespace grzejemy.Models
{
    public class Comment
    {
        Comment() 
        { 
            Verified = false;
        }
        public int Id { get; set; }

        public float PaidPrice { get; set; }

        public string? Content { get; set; }

        public bool Verified { get; set; }

        public int? ParagonId { get; set; }

        public int? QualityGrade { get; set; }

        public string? QualityComment { get; set; }
    }
}
