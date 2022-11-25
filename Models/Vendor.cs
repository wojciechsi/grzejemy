namespace grzejemy.Models
{
    public class Vendor : User
    {
        Vendor() : base()
        {
            salesPoints = new List<SalesPoint>();
            DisplayName = string.Empty;
        }

        public string DisplayName { get; set; }
        public List<SalesPoint> salesPoints { get; set; }
    }
}
