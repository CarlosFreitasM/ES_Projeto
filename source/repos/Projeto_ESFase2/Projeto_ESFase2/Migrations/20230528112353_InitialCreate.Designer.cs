﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_ESFase2.Data;

#nullable disable

namespace Projeto_ESFase2.Migrations
{
    [DbContext(typeof(ES2Context))]
    [Migration("20230528112353_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto_ESFase2.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumberVotes")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.CompetitionNominee", b =>
                {
                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("NomineeId")
                        .HasColumnType("int");

                    b.HasKey("CompetitionId", "NomineeId");

                    b.HasIndex("NomineeId");

                    b.ToTable("CompetitionNominee");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.CompetitionUser", b =>
                {
                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CompetitionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CompetitionUser");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.Nominee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nominees");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.CompetitionNominee", b =>
                {
                    b.HasOne("Projeto_ESFase2.Models.Competition", "Competition")
                        .WithMany("CompetitionNominees")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_ESFase2.Models.Nominee", "Nominee")
                        .WithMany("CompetitionNominees")
                        .HasForeignKey("NomineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Nominee");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.CompetitionUser", b =>
                {
                    b.HasOne("Projeto_ESFase2.Models.Competition", "Competition")
                        .WithMany("CompetitionUsers")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_ESFase2.Models.User", "User")
                        .WithMany("CompetitionUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.Competition", b =>
                {
                    b.Navigation("CompetitionNominees");

                    b.Navigation("CompetitionUsers");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.Nominee", b =>
                {
                    b.Navigation("CompetitionNominees");
                });

            modelBuilder.Entity("Projeto_ESFase2.Models.User", b =>
                {
                    b.Navigation("CompetitionUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
