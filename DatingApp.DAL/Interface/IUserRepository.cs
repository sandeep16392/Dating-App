using System.Threading.Tasks;
using DatingApp.DAL.Helpers;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<Like> GetLike(int userId, int recepientId);
    }
}
