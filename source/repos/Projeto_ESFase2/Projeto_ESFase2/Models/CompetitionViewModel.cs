using System.Drawing;

namespace Projeto_ESFase2.Models
{
    public class CompetitionViewModel
    {
        public int NomineeId { get; set; }
        public string CompetitionName { get; set; }

        public List<int> SelectedNomineeIds { get; set; }

        public List<Nominee> AvailableCompetition { get; set; }
    }
}
