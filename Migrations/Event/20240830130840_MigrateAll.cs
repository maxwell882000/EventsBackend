using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventsBookingBackend.Migrations.Event
{
    /// <inheritdoc />
    public partial class MigrateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "events");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "events",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state_is_reservable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    state_is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    preview_image_path = table.Column<string>(type: "text", nullable: false),
                    building_lat_long_latitude = table.Column<double>(type: "double precision", nullable: false),
                    building_lat_long_longitude = table.Column<double>(type: "double precision", nullable: false),
                    building_address = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event_aggregated_reviews",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    overall_mark = table.Column<float>(type: "real", nullable: false),
                    review_count = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_aggregated_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_event_aggregated_reviews_events_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events_images",
                schema: "events",
                columns: table => new
                {
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events_images", x => new { x.event_id, x.id });
                    table.ForeignKey(
                        name: "fk_events_images_events_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "liked_events",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_liked_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_liked_events_events_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "work_hour",
                schema: "events",
                columns: table => new
                {
                    building_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day = table.Column<int>(type: "integer", nullable: false),
                    from_hour = table.Column<int>(type: "integer", nullable: false),
                    to_hour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_work_hour", x => new { x.building_event_id, x.id });
                    table.ForeignKey(
                        name: "fk_work_hour_events_building_event_id",
                        column: x => x.building_event_id,
                        principalSchema: "events",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "events",
                columns: new[] { "id", "category_id", "created_at", "is_deleted", "name", "updated_at", "preview_image_path", "building_address", "building_lat_long_latitude", "building_lat_long_longitude" },
                values: new object[,]
                {
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Эко парк поле", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "media/preview.png", "Ташкентский центральный экопарк имени Захириддина Мухаммада Бабура", 41.309570000000001, 69.295299999999997 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ташгрэс поле", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "media/preview.png", "микрорайон ТашГРЭС, 37", 41.353098000000003, 69.336008000000007 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "225 школа поле", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "media/preview.png", "улица Каландар, 5", 41.331662999999999, 69.328024999999997 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), new Guid("48c112b1-70f5-4270-8f75-98c74bc48d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "МВЭС поле", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "media/preview.png", "ул. Мирзо Улугбека, 8А", 41.332619000000001, 69.329982000000001 }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "events_images",
                columns: new[] { "event_id", "id", "path" },
                values: new object[,]
                {
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 4, "media/preview.png" },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 1, "media/preview.png" },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 2, "media/preview.png" },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 3, "media/preview.png" }
                });

            migrationBuilder.InsertData(
                schema: "events",
                table: "work_hour",
                columns: new[] { "building_event_id", "id", "day", "from_hour", "to_hour" },
                values: new object[,]
                {
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 22, 1, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 23, 2, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 24, 3, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 25, 4, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 26, 5, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 27, 6, 10, 23 },
                    { new Guid("15f67450-ee32-4845-abe1-a7a13f43b006"), 28, 0, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 1, 1, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 2, 2, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 3, 3, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 4, 4, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 5, 5, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 6, 6, 10, 23 },
                    { new Guid("381b572f-1014-458d-9220-9aa92814c991"), 7, 0, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 8, 1, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 9, 2, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 10, 3, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 11, 4, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 12, 5, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 13, 6, 10, 23 },
                    { new Guid("c57330ee-81e3-40c4-b0e6-8fe788632e8e"), 14, 0, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 15, 1, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 16, 2, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 17, 3, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 18, 4, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 19, 5, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 20, 6, 10, 23 },
                    { new Guid("fe7e7d70-46ba-4f8e-893c-d2314c06b1cf"), 21, 0, 10, 23 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_event_aggregated_reviews_event_id",
                schema: "events",
                table: "event_aggregated_reviews",
                column: "event_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_events_is_deleted",
                schema: "events",
                table: "events",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "ix_liked_events_event_id",
                schema: "events",
                table: "liked_events",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_liked_events_is_deleted",
                schema: "events",
                table: "liked_events",
                column: "is_deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_aggregated_reviews",
                schema: "events");

            migrationBuilder.DropTable(
                name: "events_images",
                schema: "events");

            migrationBuilder.DropTable(
                name: "liked_events",
                schema: "events");

            migrationBuilder.DropTable(
                name: "work_hour",
                schema: "events");

            migrationBuilder.DropTable(
                name: "events",
                schema: "events");
        }
    }
}
