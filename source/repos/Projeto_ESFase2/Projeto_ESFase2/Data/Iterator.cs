using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Models;
using Projeto_ESFase2.Services;

namespace Projeto_ESFase2.Data
{
    public class Iterator : IIterator
    {
        private readonly ES2Context _context;
        private int _position;

        public Iterator(ES2Context context) 
        { 
            _context = context; 
            _position = 0;
        
        }

        public bool hasNext()
        {
            return _position < _context.Competitions.ToList().Count();
        }

        public object Next()
        {
            if (hasNext())
            {
                Competition competition = _context.Competitions.ToList()[_position];
                _position++;
                return competition;
            }
            throw new InvalidOperationException("End of collection reached.");
            
        }



    }
}
