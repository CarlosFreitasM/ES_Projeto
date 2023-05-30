using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_ESFase2.Models
{
    public class User
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public List<CompetitionUser> CompetitionUsers { get; set; }

    }
}
