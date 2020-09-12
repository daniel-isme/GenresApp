using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenresApp.Models
{
    public class SubGenre : Genre
    {
        public SubGenre()
        {
            HasParent = true;
        }

        public Guid ParentId { get; set; }

        public Genre Parent { get; set; }
    }
}
