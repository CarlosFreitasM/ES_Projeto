using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ESFase2.Models
{
    public class UserCompetition
    {
        public int UserId { get; set; } 
        public User User { get; set; } = null!;
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; } = null!;

    }
}
