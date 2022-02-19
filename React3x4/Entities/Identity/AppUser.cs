using Microsoft.AspNetCore.Identity;

namespace React3x4.Entities.Identity
{
    public class AppUser:IdentityUser<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

    }
}
