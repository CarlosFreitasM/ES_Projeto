namespace Projeto_ESFase2.Models
{
    public class NomineeViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }

        public List<int> SelectedNomineeIds { get; set; }

        public List<Nominee> AvailableCompetition { get; set; }
    }
}
