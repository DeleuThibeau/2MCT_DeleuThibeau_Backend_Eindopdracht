using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EindopdrachtBackEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "StreamingServices",
                columns: table => new
                {
                    StreamingServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLegal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingServices", x => x.StreamingServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("9a096e3c-abf8-4cff-8428-9a3c55927b25")),
                    URLImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                    table.ForeignKey(
                        name: "FK_Animes_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animes_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStreamingServices",
                columns: table => new
                {
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreamingServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStreamingServices", x => new { x.AnimeId, x.StreamingServiceId });
                    table.ForeignKey(
                        name: "FK_AnimeStreamingServices_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStreamingServices_StreamingServices_StreamingServiceId",
                        column: x => x.StreamingServiceId,
                        principalTable: "StreamingServices",
                        principalColumn: "StreamingServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.). Action and adventure are usually categorized together (sometimes even as 'action-adventure') because they have much in common, and many stories fall under both genres simultaneously (for instance, the James Bond series can be classified as both).", "Action" },
                    { 15, "For the more cultured/adult viewers among us (If you know what I mean ;-) )", "Hentai" },
                    { 14, "Watch a full grown person handle the difficulties in life", "Seinen" },
                    { 13, "Watch a young man grow to a hero!", "Shounen" },
                    { 12, "A new world with new adventures, LETS GOOOO!", "Isekai" },
                    { 11, "A lot of robots GUUUUUUUUUUNDAAAAAAAAAAAM", "Mecha" },
                    { 10, "Science fiction (once known as scientific romance) is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. The science or technology used may or may not be very thoroughly elaborated on.", "Sci-fi" },
                    { 9, "As the name says, watch a slice of someone's life  (it's wholesome, trust me) ", "Slice of life" },
                    { 7, "A thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. It generally has a dark or serious theme, which also makes it similar to drama.", "Thriller" },
                    { 6, "In literature, psychological fiction (also psychological realism) is a narrative genre that emphasizes interior characterization and motivation to explore the spiritual, emotional, and mental lives of the characters.", "Psychological" },
                    { 5, "A fantasy story is about magic or supernatural forces, as opposed to technology as seen in science fiction. Depending on the extent of these other elements, the story may or may not be considered to be a 'hybrid genre' series; for instance, even though the Harry Potter series canon includes the requirement of a particular gene to be a wizard, it is referred to only as a fantasy series.", "Fantasy" },
                    { 4, "Most often, however, a romance is understood to be 'love stories', emotion-driven stories that are primarily focused on the relationship between the main characters of the story. Beyond the focus on the relationship, the biggest defining characteristic of the romance genre is that a happy ending is always guaranteed,[10][11] perhaps marriage and living 'happily ever after,' or simply that the reader sees hope for the future of the romantic relationship", "Romance" },
                    { 3, "Comedy is a story that tells about a series of funny, or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basics.", "Comedy" },
                    { 2, "Drama is a mode of fictional representation through dialogue and performance. It is one of the literary genres, which is an imitation of some action. Drama is also a type of a play written for theater, television, radio, and film.", "Drama" },
                    { 8, "A horror story is told to deliberately scare or frighten the audience, through suspense, violence or shock. H. P. Lovecraft distinguishes two primary varieties in the 'Introduction' to Supernatural Horror in Literature: 1. Physical Fear or the 'mundanely gruesome' and 2. the true Supernatural Horror story or the 'Weird Tale.' The supernatural variety is occasionally called 'dark fantas',' since the laws of nature must be violated in some way, thus qualifying the story as 'fantastic.'", "Horror" }
                });

            migrationBuilder.InsertData(
                table: "StreamingServices",
                columns: new[] { "StreamingServiceId", "IsLegal", "Name" },
                values: new object[,]
                {
                    { 6, false, "KissAnime" },
                    { 7, false, "GogoAnime" },
                    { 4, true, "Funimation" },
                    { 5, true, "Hulu" },
                    { 2, true, "Amazon" },
                    { 1, true, "Netflix" },
                    { 3, true, "Crunchyroll" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "StudioId", "Name" },
                values: new object[,]
                {
                    { 17, "Studio Deen" },
                    { 16, "Kyoto animation" },
                    { 15, "Brian's Base" },
                    { 14, "Shaft" },
                    { 13, "P.A. Works" },
                    { 12, "Trigger" },
                    { 11, "J.C Staff" },
                    { 10, "Toei Animation" },
                    { 8, "Production I.G" },
                    { 7, "Studio Sunrise" },
                    { 6, "A-1 Pictures" },
                    { 5, "Mappa" },
                    { 4, "Ufotable" },
                    { 3, "Wit" },
                    { 2, "Bones" },
                    { 1, "Madhouse" },
                    { 9, "Studio Pierrot" },
                    { 18, "white fox" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_GenreId",
                table: "Animes",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_StudioId",
                table: "Animes",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStreamingServices_StreamingServiceId",
                table: "AnimeStreamingServices",
                column: "StreamingServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeStreamingServices");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "StreamingServices");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
