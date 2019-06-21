using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
