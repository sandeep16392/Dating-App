using System.Threading.Tasks;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
