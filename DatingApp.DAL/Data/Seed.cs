using System;
using System.Collections.Generic;
using System.Text;
using DatingApp.Model.EntityModels;
using Newtonsoft.Json;

namespace DatingApp.DAL.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext dataContext)
        {
            _context = dataContext;
        }

        public void SeedUserData()
        {
            var userData = System.IO.File.ReadAllText("../DatingApp.DAL/Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in users)
            {
                CreatePasswordHash("password", out var passwordSalt, out var passwordHash);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName = user.UserName.ToLower();
                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
