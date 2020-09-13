using GenresApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenresApp.Services
{
    public interface IGenresService
    {
        public List<Genre> GetAllSubGenresByGenreId(Guid? id);
        public List<Genre> GetAllGenres();
        public Genre GetGenreById(Guid? id);
        public void AddGenre(Genre newGenre);
        public void SetSubGenreToGenre(Guid subGenreId, Guid? genreId);
        public void AddSubGenreToGenre(Genre subGenre, Guid? genreId);
    }
}
