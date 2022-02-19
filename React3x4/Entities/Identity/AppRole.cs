using Microsoft.AspNetCore.Identity;

namespace React3x4.Entities.Identity
{
    public class AppRole:IdentityRole<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
