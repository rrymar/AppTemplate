using System.ComponentModel.DataAnnotations.Schema;
using AppTemplate.Database.Core;

namespace AppTemplate.Database.Users
{
    public class FullAuditEntity : AuditEntity
    {
        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public User CreatedBy { get; set; }

        public int UpdatedById { get; set; }

        [ForeignKey(nameof(UpdatedById))]
        public User UpdatedBy { get; set; }
    }
}