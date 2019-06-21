using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingApp.DAL.Data;
using DatingApp.DAL.Interface;
using DatingApp.Model.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DAL.Implementation
{
    public class PhotoRepository : BaseRepository, IPhotoRepository
    {
        public PhotoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await Context.Photos.FirstOrDefaultAsync(x => x.Id == id);
            return photo;
        }

        public async Task<Photo> GetMainPhoto(int userId)
        {
            var mainPhoto = await Context.Photos.FirstOrDefaultAsync(x => x.User.Id == userId && x.IsMain);
            return mainPhoto;
        }

        public Task<IEnumerable<Photo>> GetPhotos()
        {
            throw new NotImplementedException();
        }
    }
}
