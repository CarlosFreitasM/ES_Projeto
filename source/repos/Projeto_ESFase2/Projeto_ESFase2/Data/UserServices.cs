using Projeto_ESFase2.Services;
using Projeto_ESFase2.Models;
using Microsoft.EntityFrameworkCore;

namespace Projeto_ESFase2.Data
{
    public class UserServices : IUser
    {
        private readonly ES2Context _context;

        public UserServices(ES2Context context) {  _context = context; }

        public User GetUserById(int Id) =>
              _context.Users.FirstOrDefault(u => u.Id == Id);


        


    }
}
