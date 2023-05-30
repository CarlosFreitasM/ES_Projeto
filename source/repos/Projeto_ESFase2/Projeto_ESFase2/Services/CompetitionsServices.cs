
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Services
{
    public class CompetitionsServices
    {
        private readonly ICollection<Competition> _competitionsC;
        private readonly ICollection<User> _usersC;
        private readonly ICollection<Nominee> _nomineesC;
        public static string userName;
        public static string Email;
        public static DateTime ClosingTime;
        public static DateTime StartingTime;
        public static List<User> Users;
        public static List<Nominee> Nominees;

        public static void getClossingTime(DateTime clossingTime)
        {
            ClosingTime = clossingTime;     
        }

        public static void getStartingTime(DateTime startingTime)
        {
            StartingTime = startingTime;
        }

        public static void getListOfUsers(List<User> user)
        {
            Users = user;
        }

        public static void getListOfNominees(List<Nominee> nominee)
        {
            Nominees = nominee;
        }

        
    }
}
