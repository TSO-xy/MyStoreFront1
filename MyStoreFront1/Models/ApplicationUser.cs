using System;
using System.Collections.Generic;
namespace MyStoreFront1.Models
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ApplicationUser()
        {
            Reviews = new HashSet<Review>();
        }

        public ApplicationUser(string username)
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
