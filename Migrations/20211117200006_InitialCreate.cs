using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodReviewer",
                columns: table => new
                {
                    FoodReviewerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReviewer", x => x.FoodReviewerID);
                });

            migrationBuilder.CreateTable(
                name: "Resturant",
                columns: table => new
                {
                    ResturantID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturant", x => x.ResturantID);
                });

            migrationBuilder.CreateTable(
                name: "ReviewResturant",
                columns: table => new
                {
                    FoodReviewerID = table.Column<int>(nullable: false),
                    ResturantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewResturant", x => new { x.ResturantID, x.FoodReviewerID });
                    table.ForeignKey(
                        name: "FK_ReviewResturant_FoodReviewer_FoodReviewerID",
                        column: x => x.FoodReviewerID,
                        principalTable: "FoodReviewer",
                        principalColumn: "FoodReviewerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewResturant_Resturant_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "Resturant",
                        principalColumn: "ResturantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewResturant_FoodReviewerID",
                table: "ReviewResturant",
                column: "FoodReviewerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewResturant");

            migrationBuilder.DropTable(
                name: "FoodReviewer");

            migrationBuilder.DropTable(
                name: "Resturant");
        }
    }
}
