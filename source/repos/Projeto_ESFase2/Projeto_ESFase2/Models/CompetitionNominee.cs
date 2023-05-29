using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Projeto_ESFase2.Models
{
    public class CompetitionNominee
    {
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int NomineeId { get; set; }
        public Nominee Nominee { get; set; }
        public long numberOfVotes { get; set; }
    }
}
