using System.Threading.Tasks;

namespace DatingApp.DAL.Interface
{
    public interface IBaseRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

    }
}
