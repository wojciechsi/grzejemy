namespace grzejemy.Models
{
    public class Vendor : User
    {
        Vendor() : base()
        {
            salesPoints = new List<SalesPoint>();
            DisplayName = string.Empty;
        }

        private string DisplayName { get; set; }
        private List<SalesPoint> salesPoints { get; set; }
    }
}
