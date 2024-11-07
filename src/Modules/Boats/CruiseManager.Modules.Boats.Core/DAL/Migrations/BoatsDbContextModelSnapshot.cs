﻿// <auto-generated />
using System;
using CruiseManager.Modules.Boats.Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CruiseManager.Modules.Boats.Core.DAL.Migrations
{
    [DbContext(typeof(BoatsDbContext))]
    partial class BoatsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("boats")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.Accessory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BoatId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoatId");

                    b.ToTable("Accessory", "boats");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.Boat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Banner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Berths")
                        .HasColumnType("smallint");

                    b.Property<byte>("Cabins")
                        .HasColumnType("smallint");

                    b.Property<float>("EngineKW")
                        .HasColumnType("real");

                    b.Property<string>("HomePort")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("LOA")
                        .HasColumnType("real");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShipOwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShipOwnerId");

                    b.ToTable("Boats", "boats");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.ShipOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ShipOwner", "boats");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.Accessory", b =>
                {
                    b.HasOne("CruiseManager.Modules.Boats.Core.Entities.Boat", null)
                        .WithMany("Accessories")
                        .HasForeignKey("BoatId");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.Boat", b =>
                {
                    b.HasOne("CruiseManager.Modules.Boats.Core.Entities.ShipOwner", "Owner")
                        .WithMany("Boats")
                        .HasForeignKey("ShipOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.Boat", b =>
                {
                    b.Navigation("Accessories");
                });

            modelBuilder.Entity("CruiseManager.Modules.Boats.Core.Entities.ShipOwner", b =>
                {
                    b.Navigation("Boats");
                });
#pragma warning restore 612, 618
        }
    }
}