using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateAgency.Data.Migrations
{
    public partial class createdatase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    middlename = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    square = table.Column<double>(type: "double precision", nullable: false),
                    offertype = table.Column<int>(type: "integer", nullable: false),
                    buytype = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_UserId",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    review = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    offerid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_Review_OfferId",
                        column: x => x.offerid,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_UserId",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "firstname", "lastname", "login", "middlename", "password", "role", "telephone" },
                values: new object[] { 1, "johnburitto@gmail.com", "Андрій", "Борск", "owner", "Юрійович", "owner", 0, "+380967283875" });

            migrationBuilder.InsertData(
                table: "offers",
                columns: new[] { "id", "buytype", "description", "offertype", "price", "square", "title", "userid" },
                values: new object[] { 1, 2, "Дрейн, що сказати", 0, 3500, 3.0, "Квартира 416(3)", 1 });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "id", "offerid", "review", "userid" },
                values: new object[] { 1, 1, "Повний дрейн", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_offers_userid",
                table: "offers",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_offerid",
                table: "reviews",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_userid",
                table: "reviews",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
