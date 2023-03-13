using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Models.ViewModel
{
    public class ListAuthorDetailsVM
    {
        public ListAuthorDetailsVM()
        {
            results = new List<AuthorDetailsVM>();
        }
        public int count { get; set; }
        public int totalCount { get; set; }
        public int page { get; set; }
        public int totalPages { get; set; }
        public int? lastItemIndex { get; set; }
        public List<AuthorDetailsVM> results { get; set; }
    }
}
