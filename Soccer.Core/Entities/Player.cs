using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soccer.Core.Entities
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public long TeamId { get; set; }
        public Team? Team { get; set; }

        public Player()
        {
            FirstName = "BaseFirstName";
            LastName = "BaseLastName";
            Email = "BaseEmail";
        }
    }
}
