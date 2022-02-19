using Microsoft.AspNetCore.Identity;

namespace React3x4.Entities.Identity
{
    public class AppUserRole:IdentityUserRole<long>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
        
    }
}