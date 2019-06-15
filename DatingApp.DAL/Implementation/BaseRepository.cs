using System.Threading.Tasks;
using DatingApp.DAL.Data;
using DatingApp.DAL.Interface;

namespace DatingApp.DAL.Implementation
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }
        public void Add<T1>(T1 entity) where T1 : class
        {
            Context.Add(entity);
        }

        public void Delete<T1>(T1 entity) where T1 : class
        {
            Context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
