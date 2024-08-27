using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventsBookingBackend.Migrations.Booking
{
    /// <inheritdoc />
    public partial class MigrateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "booking");

            migrationBuilder.CreateTable(
                name: "booking_options",
                schema: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    label = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_booking_options", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "booking_types",
                schema: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    label = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_booking_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "booking_option_value",
                schema: "booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: false),
                    booking_option_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_booking_option_value", x => x.id);
                    table.ForeignKey(
                        name: "fk_booking_option_value_booking_options_booking_option_id",
                        column: x => x.booking_option_id,
                        principalSchema: "booking",
                        principalTable: "booking_options",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                schema: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    booking_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookings_booking_types_booking_type_id",
                        column: x => x.booking_type_id,
                        principalSchema: "booking",
                        principalTable: "booking_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_user_options",
                schema: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    booking_option_value_id = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    booking_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_booking_user_options", x => x.id);
                    table.ForeignKey(
                        name: "fk_booking_user_options_booking_option_value_booking_option_va",
                        column: x => x.booking_option_value_id,
                        principalSchema: "booking",
                        principalTable: "booking_option_value",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_booking_user_options_booking_options_option_id",
                        column: x => x.option_id,
                        principalSchema: "booking",
                        principalTable: "booking_options",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_booking_user_options_bookings_booking_id",
                        column: x => x.booking_id,
                        principalSchema: "booking",
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_booking_option_value_booking_option_id",
                schema: "booking",
                table: "booking_option_value",
                column: "booking_option_id");

            migrationBuilder.CreateIndex(
                name: "ix_booking_user_options_booking_id",
                schema: "booking",
                table: "booking_user_options",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "ix_booking_user_options_booking_option_value_id",
                schema: "booking",
                table: "booking_user_options",
                column: "booking_option_value_id");

            migrationBuilder.CreateIndex(
                name: "ix_booking_user_options_option_id",
                schema: "booking",
                table: "booking_user_options",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_booking_type_id",
                schema: "booking",
                table: "bookings",
                column: "booking_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking_user_options",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "booking_option_value",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "bookings",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "booking_options",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "booking_types",
                schema: "booking");
        }
    }
}
