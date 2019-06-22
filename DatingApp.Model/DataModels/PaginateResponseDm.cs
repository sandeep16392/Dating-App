using System.Collections.Generic;

namespace DatingApp.Model.DataModels
{
    public class PaginateResponseDm
    {
        public IEnumerable<UserListDm> Users { get; set; }
        public PaginationDm Pagination { get; set; }
    }
}
