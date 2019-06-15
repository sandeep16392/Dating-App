using System.Collections.Generic;
using AutoMapper;
using DatingApp.Model.DataModels;
using DatingApp.Model.EntityModels;
using DatingApp.Model.Interface;

namespace DatingApp.Model.Mappers
{
    public class UserMapper: IUserMapper
    {
        private readonly IMapper _autoMapper;

        public UserMapper(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public UserDetailsDm MapEmToDm(User userEm)
        {
            return _autoMapper.Map<UserDetailsDm>(userEm);
        }
        
        public IEnumerable<UserListDm> MapEmsToDms(IEnumerable<User> userEms)
        {
            return _autoMapper.Map<IEnumerable<UserListDm>>(userEms);
        }
    }
}
