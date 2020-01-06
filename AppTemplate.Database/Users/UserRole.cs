using AppTemplate.Database.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTemplate.Database.Users
{
    public class UserRole : AuditEntity
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}