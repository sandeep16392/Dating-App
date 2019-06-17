using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IDatingRepository : IBaseRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
