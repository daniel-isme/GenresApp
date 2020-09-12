using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenresApp.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Descriotion { get; set; }

        public bool HasParent { get; set; }

        public List<SubGenre> SubGenres { get; set; }
    }
}
