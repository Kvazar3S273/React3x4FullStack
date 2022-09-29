using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataLib.Entities.Identity;
using DataLib.Entities.Photo;
using DataLib.Entities.Comp;

namespace DataLib
{
    public class AppEFContext : IdentityDbContext<AppUser, AppRole, long, 
        IdentityUserClaim<long>,
         AppUserRole, IdentityUserLogin<long>,
         IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {

        }

        public virtual DbSet<Fnd> Fnds { get; set; }
        public virtual DbSet<Photoprint> Fotoprints { get; set; }
        public virtual DbSet<PhotoScan> Photoscans { get; set; }
        public virtual DbSet<PhotoDuplicate> PhotoDuplicates { get; set; }
        public virtual DbSet<PhotoPicture> PhotoPictures { get; set; }
        public virtual DbSet<PhotoBottle> PhotoBottles{ get; set; }
        public virtual DbSet<Xerox> Xeroxes{ get; set; }
        public virtual DbSet<BlackPrint> BlackPrints { get; set; }
        public virtual DbSet<ColorPrint> ColorPrints { get; set; }
        public virtual DbSet<Scanning> Scannings { get; set; }
        public virtual DbSet<Laminate> Laminates { get; set; }
        public virtual DbSet<Binder> Binders { get; set; }
        public virtual DbSet<UsbFlash> UsbFlashes { get; set; }
        public virtual DbSet<Discprint> Discprints { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });
        }
    }
}