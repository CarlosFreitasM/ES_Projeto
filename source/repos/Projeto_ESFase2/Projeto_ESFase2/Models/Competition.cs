using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ESFase2.Models
{
    public class Competition
    {
        public string CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionCategory { get; set;}

        public long NumberVotes { get; set; }

        public DateTime ClosingTime { get; set; }

        public DateTime StartingTime { get; set; }

        public List<User> Users { get; } = new();


    }
}
