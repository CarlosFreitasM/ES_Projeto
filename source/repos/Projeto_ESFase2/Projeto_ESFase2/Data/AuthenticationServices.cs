using Projeto_ESFase2.DTO;

namespace Projeto_ESFase2.Data
{
    public class AuthenticationServices
    {
        private readonly ES2Context _context;

        public AuthenticationServices(ES2Context context) { _context = context; }

        public List<LoginUserData> GetUsers()
        {
            List<LoginUserData> user = _context.Users.Select(u => new LoginUserData
            {
                Id = u.Id,
                UserName = u.Name,
                IsAdmin = u.IsAdmin
            }).ToList();

            return user;
        }
    }
}
