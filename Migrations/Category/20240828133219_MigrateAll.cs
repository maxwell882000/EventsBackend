using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsBookingBackend.Migrations.Category
{
    /// <inheritdoc />
    public partial class MigrateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "categories");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    icon = table.Column<string>(type: "text", nullable: false),
                    bg_color = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "categories",
                table: "categories",
                columns: new[] { "id", "bg_color", "created_at", "icon", "is_active", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), "#12B76A1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FootballIcon", false, false, "Футбол", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5a778261-6711-407a-8228-19319cbb77fa"), "#9E77ED1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AllIcon", true, false, "Все", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b8a1187-b5bc-4504-8614-532cb27f974c"), "#0BA5EC1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PingPongIcon", false, false, "Пинг понг", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef180f1c-66c0-43be-bf8b-cc98d24e0227"), "#F790091F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BasketballIcon", false, false, "Баскетбол", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5e9698a-9787-4836-a1ba-8e4c6316a9f3"), "#F63D681F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TennisIcon", false, false, "Теннис", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_is_deleted",
                schema: "categories",
                table: "categories",
                column: "is_deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories",
                schema: "categories");
        }
    }
}
