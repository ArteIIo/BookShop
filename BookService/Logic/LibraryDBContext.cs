using Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LibraryDBContext : DbContext
    {
        IDataProvider data;

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" }
            );
            modelBuilder.Entity<Author>().HasData(
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
                new Author() { AuthorId = 4, Name = "Name3", Surname = "Surname3" },
                new Author() { AuthorId = 5, Name = "Name4", Surname = "Surname4" }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
                new Genre() { GenreId = 4, Name = "Genre3" },
                new Genre() { GenreId = 5, Name = "Genre4" }
            );

            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre() { BookGenreId = 1, BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookGenreId = 2, BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookGenreId = 3, BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookGenreId = 4, BookIndex = 2, GenreIndex = 4 },
                new BookGenre() { BookGenreId = 5, BookIndex = 2, GenreIndex = 5 },
                new BookGenre() { BookGenreId = 6, BookIndex = 1, GenreIndex = 5 }
            );
            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor() { BookAuthorId = 1, BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookAuthorId = 2, BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookAuthorId = 3, BookIndex = 2, AuthorIndex = 3 },
                new BookAuthor() { BookAuthorId = 4, BookIndex = 2, AuthorIndex = 4 },
                new BookAuthor() { BookAuthorId = 5, BookIndex = 2, AuthorIndex = 5 },
                new BookAuthor() { BookAuthorId = 6, BookIndex = 1, AuthorIndex = 5 }
            );
        }

        /// <summary>
        /// Set of books
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Set of authors
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Set of genres
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Set of books to genres
        /// </summary>
        public DbSet<BookGenre> BookToGenre { get; set; }

        /// <summary>
        /// Set of books to authors
        /// </summary>
        public DbSet<BookAuthor> BookToAuthor { get; set; }
    }
}
