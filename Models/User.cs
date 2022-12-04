using Microsoft.AspNetCore.Identity;

namespace grzejemy.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            SalesPoints = new List<SalesPoint>();
        }
        public List<SalesPoint> SalesPoints { get; set; }
    }
}
