﻿// <auto-generated />
using System;
using AngielskiNauka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngielskiNauka.Migrations
{
    [DbContext(typeof(AaaswswContext))]
    partial class AaaswswContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngielskiNauka.Models.Dane", b =>
                {
                    b.Property<int>("DaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DaneId"));

                    b.Property<string>("Ang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAkt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoziomId")
                        .HasColumnType("int");

                    b.Property<int>("Stan")
                        .HasColumnType("int");

                    b.HasKey("DaneId");

                    b.HasIndex(new[] { "PoziomId" }, "IX_Danes_PoziomId");

                    b.ToTable("Danes");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Poziom", b =>
                {
                    b.Property<int>("PoziomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoziomId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoziomId");

                    b.ToTable("Pozioms");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("Ok")
                        .HasColumnType("int");

                    b.Property<int>("PoziomId")
                        .HasColumnType("int");

                    b.Property<string>("Repeat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PoziomId" }, "IX_Stats_PoziomId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Ustawienia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ustawienias");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Dane", b =>
                {
                    b.HasOne("AngielskiNauka.Models.Poziom", "Poziom")
                        .WithMany("Danes")
                        .HasForeignKey("PoziomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poziom");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Stat", b =>
                {
                    b.HasOne("AngielskiNauka.Models.Poziom", "Poziom")
                        .WithMany("Stats")
                        .HasForeignKey("PoziomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poziom");
                });

            modelBuilder.Entity("AngielskiNauka.Models.Poziom", b =>
                {
                    b.Navigation("Danes");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
