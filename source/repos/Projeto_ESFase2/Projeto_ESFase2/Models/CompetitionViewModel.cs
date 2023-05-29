using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Projeto_ESFase2.Models
{
    public class CompetitionViewModel
    {
        public int NomineeId { get; set; }

        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public List<int> SelectedNomineeIds { get; set; }

        public List<Nominee> AvailableCompNom { get; set; }

        public List<Nominee> AvailableNominees { get; set; }
    }
}
