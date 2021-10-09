using Microsoft.EntityFrameworkCore.Migrations;

namespace FAQapp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    FAQId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    YearFormed = table.Column<string>(nullable: true),
                    BandWebsite = table.Column<string>(nullable: true),
                    SecondLink = table.Column<string>(nullable: true),
                    GenreId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.FAQId);
                    table.ForeignKey(
                        name: "FK_FAQs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAQs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "hist", "History" },
                    { "gen", "General" },
                    { "link", "Websites" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "sym-metal", "Symphonic Metal" },
                    { "spd-metal", "Speed Metal" },
                    { "pow-metal", "Power Metal" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "FAQId", "BandWebsite", "CategoryId", "Description", "GenreId", "Name", "SecondLink", "YearFormed" },
                values: new object[,]
                {
                    { 1, null, "hist", null, "sym-metal", "Nightwish", null, "1996" },
                    { 2, null, "gen", "Finland's Nightwish are an award-winning, best-selling symphonic metal band fronted by Floor Jansen, their third female vocalist.", "sym-metal", "Nightwish", null, null },
                    { 3, "https://www.nightwish.com/", "link", null, "sym-metal", "Nightwish", "https://open.spotify.com/artist/2NPduAUeLVsfIauhRwuft1", null },
                    { 4, null, "hist", null, "spd-metal", "DragonForce", null, "1999" },
                    { 5, null, "gen", "Known as the fastest band in the world, Grammy-nominated extreme power metal band DragonForce is based in London, England.", "spd-metal", "DragonForce", null, null },
                    { 6, "https://dragonforce.com/", "link", null, "spd-metal", "DragonForce", "https://open.spotify.com/artist/2pH3wEn4eYlMMIIQyKPbVR", null },
                    { 7, null, "hist", null, "pow-metal", "Battle Beast", null, "2005" },
                    { 8, null, "gen", "Famous for their energetic shows, incredibly catchy choruses and odd sense of humour, Finland’s Battle Beast are destined for glory.", "pow-metal", "Battle Beast", null, null },
                    { 9, "https://battlebeast.fi/", "link", null, "pow-metal", "Battle Beast", "https://open.spotify.com/artist/7k5jeohQCF20a8foBD9ize", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_CategoryId",
                table: "FAQs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_GenreId",
                table: "FAQs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
