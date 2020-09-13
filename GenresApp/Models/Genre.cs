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
            Id = Guid.NewGuid();
            SubGenreIds = new List<Guid>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasParent { get => ParentId.HasValue; }
        public List<Guid> SubGenreIds { get; set; }
    }
}
