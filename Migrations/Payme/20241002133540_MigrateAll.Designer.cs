﻿// <auto-generated />
using System;
using EventsBookingBackend.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventsBookingBackend.Migrations.Payme
{
    [DbContext(typeof(PaymeDbContext))]
    [Migration("20241002133540_MigrateAll")]
    partial class MigrateAll
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("payme")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventsBookingBackend.Infrastructure.Payment.Payme.Entities.TransactionDetail<EventsBookingBackend.Infrastructure.Payment.Payme.ValueObjects.Account>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<long>("CancelTime")
                        .HasColumnType("bigint")
                        .HasColumnName("cancel_time");

                    b.Property<long>("CreateTime")
                        .HasColumnType("bigint")
                        .HasColumnName("create_time");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("PaymeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("payme_id");

                    b.Property<long>("PerformTime")
                        .HasColumnType("bigint")
                        .HasColumnName("perform_time");

                    b.Property<int>("Reason")
                        .HasColumnType("integer")
                        .HasColumnName("reason");

                    b.Property<int>("State")
                        .HasColumnType("integer")
                        .HasColumnName("state");

                    b.Property<long>("Time")
                        .HasColumnType("bigint")
                        .HasColumnName("time");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_transaction_details");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("ix_transaction_details_is_deleted");

                    b.HasIndex("PaymeId")
                        .IsUnique()
                        .HasDatabaseName("ix_transaction_details_payme_id");

                    b.HasIndex("Time")
                        .HasDatabaseName("ix_transaction_details_time");

                    b.ToTable("transaction_details", "payme");
                });

            modelBuilder.Entity("EventsBookingBackend.Infrastructure.Payment.Payme.Entities.TransactionDetail<EventsBookingBackend.Infrastructure.Payment.Payme.ValueObjects.Account>", b =>
                {
                    b.OwnsOne("EventsBookingBackend.Infrastructure.Payment.Payme.ValueObjects.Account", "Account", b1 =>
                        {
                            b1.Property<Guid>("TransactionDetailId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid")
                                .HasColumnName("account_booking_id");

                            b1.HasKey("TransactionDetailId");

                            b1.ToTable("transaction_details", "payme");

                            b1.WithOwner()
                                .HasForeignKey("TransactionDetailId")
                                .HasConstraintName("fk_transaction_details_transaction_details_id");
                        });

                    b.OwnsMany("EventsBookingBackend.Infrastructure.Payment.Payme.ValueObjects.Receiver", "Receivers", b1 =>
                        {
                            b1.Property<Guid>("TransactionDetailId")
                                .HasColumnType("uuid")
                                .HasColumnName("transaction_detail_account_id");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.HasKey("TransactionDetailId", "Id")
                                .HasName("pk_receiver");

                            b1.ToTable("receiver", "payme");

                            b1.WithOwner()
                                .HasForeignKey("TransactionDetailId")
                                .HasConstraintName("fk_receiver_transaction_details_transaction_detail_account_id");
                        });

                    b.Navigation("Account");

                    b.Navigation("Receivers");
                });
#pragma warning restore 612, 618
        }
    }
}
