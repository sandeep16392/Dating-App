﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Model.DataModels
{
    public class UserListDm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string KnownAs { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }

    }
}
