using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the genre's service
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Get genre value by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>genre by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        Genre GetGenreById(int id);

        /// <summary>
        /// Return collection of genres
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="newGenre">New genre</param>
        void AddGenre(Genre newGenre);

        /// <summary>
        /// Remove genre by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Deleted Gender</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        Genre RemoveGenre(int id);
    }
}
