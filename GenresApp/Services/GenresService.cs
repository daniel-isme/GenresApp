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

        public List<Genre> GetAllGenres()
        {
            return genres;
        }

        public Genre GetGenreById(Guid? id)
        {
            var genre = genres.FirstOrDefault(g => g.Id == id);

            return genre;
        }

        public List<Genre> GetAllSubGenresByGenreId(Guid? id)
        {
            var genre = GetGenreById(id);
            List<Genre> subGenres = new List<Genre>();

            foreach (var subGenreId in genre.SubGenreIds)
            {
                var subGenre = GetGenreById(subGenreId);
                subGenres.Add(subGenre);
            }

            return subGenres;
        }

        public void AddGenre(Genre newGenre)
        {
            genres.Add(newGenre);
        }

        public void SetSubGenreToGenre(Guid subGenreId, Guid? genreId)
        {
            if (genreId == null)
                return;

            var genre = genres.FirstOrDefault(g => g.Id == genreId);

            genre.SubGenreIds.Add(subGenreId);
        }

        public void AddSubGenreToGenre(Genre subGenre, Guid? genreId)
        {
            if (genreId == null)
                return;

            genres.Add(subGenre);

            SetSubGenreToGenre(subGenre.Id, genreId);
        }
    }
}
