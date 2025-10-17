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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("Users")
                        .HasIndex(i => i.Key)
                        .IsUnique();

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
