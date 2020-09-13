using GenresApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenresApp.Services
{
    public sealed class GenresService : IGenresService
    {
        private readonly List<Genre> genres = new List<Genre>();

        public Genre GetGenre(Guid id)
        {
            var genre = genres.FirstOrDefault(g => g.Id == id);

            return genre;
        }

        public void AddGenre(Genre newGenre)
        {
            genres.Add(newGenre);
        }

        public void SetSubGenreToGenre(Guid subGenreId, Guid genreId)
        {
            var genre = genres.FirstOrDefault(g => g.Id == genreId);

            genre.SubGenreIds.Add(subGenreId);
        }

        public void AddSubGenreToGenre(Genre subGenre, Guid genreId)
        {
            genres.Add(subGenre);

            SetSubGenreToGenre(subGenre.Id, genreId);
        }
    }
}
