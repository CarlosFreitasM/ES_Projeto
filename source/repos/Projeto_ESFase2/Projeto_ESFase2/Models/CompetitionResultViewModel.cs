namespace Projeto_ESFase2.Models
{
    public class CompetitionResultViewModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public long TotalVotes { get; set; }

        public List<Nominee> AvailableCompNom { get; set; }

        public List<CompetitionNominee> NumberOfVotesPer { get; set; }
    }
}
