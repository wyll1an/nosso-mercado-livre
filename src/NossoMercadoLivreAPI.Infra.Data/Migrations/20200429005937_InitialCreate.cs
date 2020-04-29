using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NossoMercadoLivreAPI.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    document = table.Column<string>(maxLength: 20, nullable: false),
                    phone_number = table.Column<string>(maxLength: 20, nullable: false),
                    password_hash = table.Column<string>(maxLength: 100, nullable: false),
                    created_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
