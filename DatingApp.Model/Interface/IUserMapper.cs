using System;
using System.Collections.Generic;
using System.Text;
using DatingApp.Model.DataModels;
using DatingApp.Model.EntityModels;

namespace DatingApp.Model.Interface
{
    public interface IUserMapper
    {
        UserDetailsDm MapEmToDm(User userEm);
        IEnumerable<UserListDm> MapEmsToDms(IEnumerable<User> userEms);
    }
}
