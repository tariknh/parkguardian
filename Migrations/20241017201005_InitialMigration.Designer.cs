﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

#nullable disable

namespace TodoApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241017201005_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParkGuard.Models.Guard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Guards");
                });

            modelBuilder.Entity("ParkGuard.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GuardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastCheck")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuardId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ParkGuard.Models.Location", b =>
                {
                    b.HasOne("ParkGuard.Models.Guard", "Guard")
                        .WithMany("CheckedLocations")
                        .HasForeignKey("GuardId");

                    b.Navigation("Guard");
                });

            modelBuilder.Entity("ParkGuard.Models.Guard", b =>
                {
                    b.Navigation("CheckedLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
