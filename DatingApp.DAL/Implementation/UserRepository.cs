using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DAL.Data;
using DatingApp.DAL.Helpers;
using DatingApp.DAL.Interface;
using DatingApp.Model.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DAL.Implementation
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<PagedList<User>> GetUsers(PaginationParams pageParams)
        {
            var users = Context.Users.Include(x => x.Photos).OrderByDescending(x => x.LastActive)
                .Where(x => x.Gender == pageParams.Gender && x.Id != pageParams.UserId);
            if (pageParams.MaxAge != 99 || pageParams.MinAge != 18)
            {
                var minDob = DateTime.Today.AddYears(-pageParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-pageParams.MinAge);
                users = users.Where(x => x.DateOfBirth >= minDob && x.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(pageParams.OrderBy))
            {
                switch (pageParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(x => x.Created);
                        break;
                    default:
                        users = users.OrderByDescending(x => x.LastActive);
                        break;
                }
            }
            return await PagedList<User>.CreateAsync(users, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await Context.Users.Include(x => x.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
