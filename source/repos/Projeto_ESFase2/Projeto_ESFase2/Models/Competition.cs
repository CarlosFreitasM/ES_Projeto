using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ESFase2.Models
{
    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set;}

        public long NumberVotes { get; set; }

        public DateTime ClosingTime { get; set; }

        public DateTime StartingTime { get; set; }

        public virtual List<CompetitionUser> CompetitionUsers { get; set; }

        public virtual List<CompetitionNominee> CompetitionNominees { get; set; }


    }
}
