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
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
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
                columns: new[] { "id", "bg_color", "created_at", "icon", "is_default", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1a38ebe5-31fc-4550-959f-cabb23197df1"), "#0BA5EC1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PingPongIcon", false, false, "Пинг понг", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), "#12B76A1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FootballIcon", false, false, "Футбол", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f70cd4c-82d0-4c61-8684-1b6e638cfd38"), "#9E77ED1F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AllIcon", true, false, "Все", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b18bc270-82a2-4b44-afb0-a05fe2dd9d3c"), "#F790091F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BasketballIcon", false, false, "Баскетбол", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f18e521e-ae4e-49dc-8a96-f5f79e665c8c"), "#F63D681F", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TennisIcon", false, false, "Теннис", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
