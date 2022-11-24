using Microsoft.AspNetCore.Identity;

namespace grzejemy.Server.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            IsBanned = false;
        }
        
        /**
         * All authentication mechanism (so do ID field)
         * is realized by parent class
         */

        private bool IsBanned {get; set;}

    }
}