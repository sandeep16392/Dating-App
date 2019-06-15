using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Model.DataModels
{
    public class PhotosDm
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}
