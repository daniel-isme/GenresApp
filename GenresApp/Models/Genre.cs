using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenresApp.Models
{
    public class Genre
    {
        [Key]
        public Int32 Id { get; set; }

        [ForeignKey("Genre")]
        public Int32? ParentId { get; set; }

        public Genre Parent { get; set; }

        public string Name { get; set; }

        public string Descriotion { get; set; }

        public List<Genre> SubGenres { get; set; }
    }
}
