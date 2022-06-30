using System.Threading.Tasks;

namespace PatrikBanko_Zavrsni
{
    public interface IAuth
    {
        Task<string> SignUpWithEmailAndPassword(string email, string password);
        Task<string> LoginWithEmailAndPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();
    }
}
