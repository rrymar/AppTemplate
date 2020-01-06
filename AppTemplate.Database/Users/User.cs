using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppTemplate.Database.Core;
using Microsoft.EntityFrameworkCore;

namespace AppTemplate.Database.Users
{
    public class User : AuditEntity
    {
        [StringLength(32)]
        public string Username { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }

        [StringLength(40)]
        public string PasswordSalt { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public virtual List<UserRole> Roles { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.Roles).WithOne(e => e.User);
            modelBuilder.Entity<User>().HasIndex(e => e.Username);

            modelBuilder.Entity<User>().Property(p => p.FullName)
                .HasComputedColumnSql($"CONCAT({nameof(FirstName)},' ', {nameof(LastName)})");
        }
    }

    public static class KnownUsers
    {
        public const int System = 0;

        public static readonly int[] SystemUsers = { System };
    }
}