using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logic.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "BookToAuthor",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookIndex = table.Column<int>(nullable: false),
                    AuthorIndex = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookToAuthor", x => x.BookAuthorId);
                    table.ForeignKey(
                        name: "FK_BookToAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookToAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookToGenre",
                columns: table => new
                {
                    BookGenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookIndex = table.Column<int>(nullable: false),
                    GenreIndex = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    GenreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookToGenre", x => x.BookGenreId);
                    table.ForeignKey(
                        name: "FK_BookToGenre_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookToGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Name0", "Surname0" },
                    { 2, "Name1", "Surname1" },
                    { 3, "Name2", "Surname2" },
                    { 4, "Name3", "Surname3" },
                    { 5, "Name4", "Surname4" }
                });

            migrationBuilder.InsertData(
                table: "BookToAuthor",
                columns: new[] { "BookAuthorId", "AuthorId", "AuthorIndex", "BookId", "BookIndex" },
                values: new object[,]
                {
                    { 6, null, 5, null, 1 },
                    { 4, null, 4, null, 2 },
                    { 3, null, 3, null, 2 },
                    { 5, null, 5, null, 2 },
                    { 1, null, 1, null, 1 },
                    { 2, null, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookToGenre",
                columns: new[] { "BookGenreId", "BookId", "BookIndex", "GenreId", "GenreIndex" },
                values: new object[,]
                {
                    { 1, null, 1, null, 1 },
                    { 2, null, 1, null, 2 },
                    { 3, null, 2, null, 3 },
                    { 4, null, 2, null, 4 },
                    { 5, null, 2, null, 5 },
                    { 6, null, 1, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Name" },
                values: new object[,]
                {
                    { 2, "Book1" },
                    { 1, "Book0" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 4, "Genre3" },
                    { 1, "Genre0" },
                    { 2, "Genre1" },
                    { 3, "Genre2" },
                    { 5, "Genre4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookToAuthor_AuthorId",
                table: "BookToAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookToAuthor_BookId",
                table: "BookToAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookToGenre_BookId",
                table: "BookToGenre",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookToGenre_GenreId",
                table: "BookToGenre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookToAuthor");

            migrationBuilder.DropTable(
                name: "BookToGenre");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
