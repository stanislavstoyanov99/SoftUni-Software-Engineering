﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P03_FootballBetting.Data;

namespace P03_FootballBetting.Data.Migrations
{
    [DbContext(typeof(FootballBettingContext))]
    [Migration("20191111203101_ApliedDataSeeder")]
    partial class ApliedDataSeeder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Bet", b =>
                {
                    b.Property<int>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("GameId");

                    b.Property<int>("Prediction")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("UserId");

                    b.HasKey("BetId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.HasKey("ColorId");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorId = 1,
                            Name = "Black"
                        },
                        new
                        {
                            ColorId = 2,
                            Name = "White"
                        },
                        new
                        {
                            ColorId = 3,
                            Name = "Red"
                        });
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Italy"
                        });
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AwayTeamBetRate");

                    b.Property<int>("AwayTeamGoals");

                    b.Property<int>("AwayTeamId");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("DATETIME2");

                    b.Property<double>("DrawBetRate");

                    b.Property<double>("HomeTeamBetRate");

                    b.Property<int>("HomeTeamGoals");

                    b.Property<int>("HomeTeamId");

                    b.Property<int>("Result");

                    b.HasKey("GameId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsInjured");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<int>("PositionId");

                    b.Property<byte>("SquadNumber")
                        .HasMaxLength(3);

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.PlayerStatistic", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Assists");

                    b.Property<int>("MinutesPlayed");

                    b.Property<int>("ScoredGoals");

                    b.HasKey("GameId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerStatistics");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("PositionId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            PositionId = 1,
                            Name = "attacker"
                        },
                        new
                        {
                            PositionId = 2,
                            Name = "deffender"
                        });
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Team", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<decimal>("Budget");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(true);

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true);

                    b.Property<int>("PrimaryKitColorId");

                    b.Property<int>("SecondaryKitColorId");

                    b.Property<int>("TownId");

                    b.HasKey("TeamId");

                    b.HasIndex("PrimaryKitColorId");

                    b.HasIndex("SecondaryKitColorId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Town", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("TownId");

                    b.HasIndex("CountryId");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            TownId = 1,
                            CountryId = 1,
                            Name = "Sofia"
                        },
                        new
                        {
                            TownId = 2,
                            CountryId = 2,
                            Name = "Los Angelis"
                        });
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Bet", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Game", "Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.User", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Game", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Team", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.Team", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Player", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.PlayerStatistic", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Game", "Game")
                        .WithMany("PlayerStatistics")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.Player", "Player")
                        .WithMany("PlayerStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Team", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Color", "PrimaryKitColor")
                        .WithMany("PrimaryKitTeams")
                        .HasForeignKey("PrimaryKitColorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.Color", "SecondaryKitColor")
                        .WithMany("SecondaryKitTeams")
                        .HasForeignKey("SecondaryKitColorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("P03_FootballBetting.Data.Models.Town", "Town")
                        .WithMany("Teams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("P03_FootballBetting.Data.Models.Town", b =>
                {
                    b.HasOne("P03_FootballBetting.Data.Models.Country", "Country")
                        .WithMany("Towns")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
