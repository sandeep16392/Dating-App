using System.Threading.Tasks;
using DatingApp.DAL.Helpers;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        Task<PagedList<User>> GetUsers(PaginationParams pageParams);
        Task<User> GetUser(int id);
    }
}
