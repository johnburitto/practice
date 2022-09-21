using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateAgency.Data.Migrations
{
    public partial class updatedatase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "realtors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    middlename = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    agencyid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realtors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Realtor_AgencyId",
                        column: x => x.agencyid,
                        principalTable: "agencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "agencies",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Capitan Soap" });

            migrationBuilder.InsertData(
                table: "realtors",
                columns: new[] { "id", "agencyid", "experience", "firstname", "lastname", "middlename" },
                values: new object[] { 1, 1, 5, "Петро", "Петренко", "Петрович" });

            migrationBuilder.CreateIndex(
                name: "IX_realtors_agencyid",
                table: "realtors",
                column: "agencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realtors");

            migrationBuilder.DropTable(
                name: "agencies");
        }
    }
}
