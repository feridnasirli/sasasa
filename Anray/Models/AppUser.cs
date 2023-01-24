using Microsoft.AspNetCore.Identity;

namespace Anray.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
