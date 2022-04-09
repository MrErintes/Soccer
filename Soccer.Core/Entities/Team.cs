using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soccer.Core.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string ManagerEmail { get; set; }

        public List<Player> Players;

        public Team()
        {
            Name = "BaseName";
            ManagerEmail = "BaseEmail";
            Players = new List<Player>();
        }
    }
}
