using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Projeto_ESFase2.Models
{
    public class AddNomineeViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public int SelectedNomineeIds { get; set; }
        public List<Nominee> AvailableNominee { get; set; }
    }
}
