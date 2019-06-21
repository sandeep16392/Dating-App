using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Model.EntityModels;

namespace DatingApp.DAL.Interface
{
    public interface IPhotoRepository : IBaseRepository
    {
        Task<Photo> GetPhoto(int id);
        Task<IEnumerable<Photo>> GetPhotos();
        Task<Photo> GetMainPhoto(int userId);
    }
}
