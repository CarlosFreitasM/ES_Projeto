namespace Projeto_ESFase2.Services
{
    public static class UsersServices
    {
        public static string userName;
        public static string Email;
        public static bool isAdmin;

        public static void getUserName(string username)
        {
            userName = username;
        }
        public static void getUserEmail(string email)
        {
            Email = email;
        }
        public static void getUserAdmin(bool admin)
        {
            isAdmin = admin;
        }

        public static void getUserInfo(string username, string email, bool admin)
        {
            userName = username;
            Email = email;
            isAdmin = admin;
        }

        public static void resetLocalData()
        {
            userName = null;
            Email = null;
            isAdmin = false;
        }
    }
}
