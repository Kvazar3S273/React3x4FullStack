using Microsoft.AspNetCore.Identity;

namespace DataLib.Entities.Identity
{
    public class AppUser:IdentityUser<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public string? Photo { get; set; }
    }
}
