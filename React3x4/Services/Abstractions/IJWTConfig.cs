

using DataLib.Entities.Identity;

namespace React3x4.Services.Abstractions
{
    public interface IJWTConfig
    {
        public string CreateToken(AppUser user);
    }
}
