using Core.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Database
{
    public class UserPreferense 
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string Value { get; set; }
    }
}
