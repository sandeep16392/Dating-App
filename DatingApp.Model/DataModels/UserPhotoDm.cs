using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Model.DataModels
{
    public class UserPhotoDm
    {
        public string url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; }

        public UserPhotoDm()
        {
            DateAdded = DateTime.Now;
        }
    }
}
