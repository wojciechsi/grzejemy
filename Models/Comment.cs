namespace grzejemy.Models
{
    public class Comment
    {
        Comment() 
        { 
            Verified = false;
        }
        public int Id { get; set; }

        private float PaidPrice { get; set; }

        private string? Content { get; set; }

        private bool Verified { get; set; }

        private int? ParagonId { get; set; }

        private int? QualityGrade { get; set; }

        private string? QualityComment { get; set; }
    }
}
