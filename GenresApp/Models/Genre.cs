using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenresApp.Models
{
    public class Genre
    {
        public Genre()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> SubGenreIds { get; set; }
    }
}
