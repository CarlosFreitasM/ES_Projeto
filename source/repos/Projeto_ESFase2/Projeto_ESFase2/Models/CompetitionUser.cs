using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Projeto_ESFase2.Models
{
    public class CompetitionUser
    {

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
