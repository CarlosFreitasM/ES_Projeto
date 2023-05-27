using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ESFase2.Models
{
    public class GroupedNominee
    {
        public string NomineeType { get; set; }

        public List<Nominee> Items { get; set; }
    }
    
}
