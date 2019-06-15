using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.DAL.Data;
using DatingApp.DAL.Interface;
using DatingApp.Model.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DAL.Implementation
{
    public class DatingRepository : BaseRepository, IDatingRepository
    {
        public DatingRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await Context.Users.Include(x => x.Photos).ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await Context.Users.Include(x => x.Photos).FirstOrDefaultAsync(u=>u.Id == id);

            return user;
        }
    }
}
