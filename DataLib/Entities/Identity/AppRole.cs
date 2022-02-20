using Microsoft.AspNetCore.Identity;

namespace DataLib.Entities.Identity
{
    public class AppRole:IdentityRole<long>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
