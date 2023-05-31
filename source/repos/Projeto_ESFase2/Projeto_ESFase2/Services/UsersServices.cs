namespace Projeto_ESFase2.Services
{
    public static class UsersServices
    {
        public static int userId;
        public static string userName;
        public static string Email;
        public static bool isAdmin;

        public static void setUserName(string username)
        {
            userName = username;
        }
        public static void setUserEmail(string email)
        {
            Email = email;
        }
        public static void setUserAdmin(bool admin)
        {
            isAdmin = admin;
        }

        public static void setUserInfo(int id, string username, string email, bool admin)
        {
            userId = id;
            userName = username;
            Email = email;
            isAdmin = admin;
        }

        public static void resetLocalData()
        {
            userId = 0;
            userName = null;
            Email = null;
            isAdmin = false;
        }
    }
}