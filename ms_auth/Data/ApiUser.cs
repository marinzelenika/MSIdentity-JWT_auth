using Microsoft.AspNetCore.Identity;

namespace ms_auth.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
