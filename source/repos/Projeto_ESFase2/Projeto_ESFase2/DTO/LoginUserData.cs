namespace Projeto_ESFase2.DTO
{
    public class LoginUserData
    {
        public static string UserSession { get; set; }
        public static int UserId { get; }

        public LoginUserData(string userSession, int userId) 
        {
            UserSession = userSession;
  
        }
    }
}
