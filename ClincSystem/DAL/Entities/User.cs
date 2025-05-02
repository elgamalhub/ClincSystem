using Microsoft.AspNetCore.Identity;

namespace ClincSystem.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }

}
