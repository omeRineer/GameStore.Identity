using Application.Utilities.Helpers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("Users")
                        .HasIndex(i => i.Key)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .HasData(new List<User>
                        {
                            new()
                            {
                                Id = Guid.Parse("2f1b6f4a-3b0d-4f4c-94b8-9d5c4a7aaf25"),
                                Key = "GMSTXYR35",
                                FirstName = "Super Admin",
                                LastName = "User",
                                UserName = "superadmin",
                                Password = "123456",
                                BirthdayDate = new DateTime(2025, 10, 1),
                                Email = "",
                                Phone = "",
                                CreateDate = new DateTime(2025, 10, 1),
                                EditDate = new DateTime(2025, 10, 1)
                            }
                        });

            modelBuilder.Entity<Role>()
                        .ToTable("Roles");

            modelBuilder.Entity<UserRole>()
                        .ToTable("UserRoles");

            modelBuilder.Entity<Permission>()
                        .ToTable("Permissions");

            modelBuilder.Entity<UserPermission>()
                        .ToTable("UserPermissions");

            modelBuilder.Entity<RolePermission>()
                        .ToTable("RolePermissions");

            modelBuilder.Entity<UserClaim>()
                        .ToTable("UserClaims");
        }
    }
}
