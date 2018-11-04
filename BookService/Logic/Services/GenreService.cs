using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Models;

namespace Logic
{
    public class GenreService : IGenreService
    {
        /// <summary>
        /// DB context
        /// </summary>
        private LibraryDBContext dBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenreService"/> class.
        /// </summary>
        /// <param name="dBContext">DB context</param>
        public GenreService(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="newGenre">New genre</param>
        public void AddGenre(Genre newGenre)
        {
            dBContext.Genres.Add(newGenre);
            dBContext.SaveChanges();
        }

        /// <summary>
        /// Get genre value by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>genre by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Genre GetGenreById(int id)
        {
            try
            {
                Genre genre = dBContext.Genres.First(item => item.GenreId == id);

                return genre;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }

        /// <summary>
        /// Return collection of genres
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Genre> GetGenres()
        {
            return dBContext.Genres;
        }

        /// <summary>
        /// Remove genre by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Deleted Genre</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        public Genre RemoveGenre(int id)
        {
            try
            {
                Genre deletedGenre = null;
                if (!dBContext.BookToGenre.Any(items => items.GenreIndex == id))
                {
                    deletedGenre = dBContext.Genres.First(item => item.GenreId == id);
                    if (deletedGenre == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    dBContext.Genres.Remove(deletedGenre);
                    dBContext.SaveChanges();
                }

                return deletedGenre;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }
    }
}
