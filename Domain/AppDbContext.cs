using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using valexis.Domain.Entities;
using valexis.Service;

namespace valexis.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ce93edcd-47c9-4151-b034-a291b8ec8d10",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "37be1e66-f9cd-4a11-9cd3-4575cf0ebbcd",
                UserName = "sivival",
                NormalizedUserName = "SIVIVAL",
                Email = Config.CompanyEmail,
                NormalizedEmail = Config.CompanyEmail.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Sivi201426"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ce93edcd-47c9-4151-b034-a291b8ec8d10",
                UserId = "37be1e66-f9cd-4a11-9cd3-4575cf0ebbcd"
            });
        }
    }
}
