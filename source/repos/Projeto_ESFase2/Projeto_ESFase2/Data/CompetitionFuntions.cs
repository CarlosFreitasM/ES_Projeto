﻿using Microsoft.CodeAnalysis;
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Data
{
    public class CompetitionFuntions
    {
        private readonly ES2Context _context;

        public CompetitionFuntions(ES2Context context) { _context = context; }

        public void incrementCompetitionNomineeNumberVotes(CompetitionViewModel viewModel, Competition competition)
        {
            long votes = 0;
            var votedCompetitionNominee = competition.CompetitionNominees.Where(c => c.CompetitionId == viewModel.CompetitionId);


            if (votedCompetitionNominee != null)
            {
                foreach (var item in votedCompetitionNominee)
                {
                    if (item.NomineeId == viewModel.SelectedNominee)
                    {
                        votes = item.numberOfVotes++;
                    }
                    
                }

            }
            
        }


    }
}
