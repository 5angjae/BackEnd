﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oneline.Data;

namespace oneline.Migrations
{
    [DbContext(typeof(OneLineContext))]
    partial class OneLineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("oneline.Models.Achievement", b =>
                {
                    b.Property<int>("AchIdx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("QuestIdx")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("WorldIdx")
                        .HasColumnType("int");

                    b.HasKey("AchIdx");

                    b.HasIndex("QuestIdx");

                    b.HasIndex("UserId");

                    b.HasIndex("WorldIdx");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("oneline.Models.Kart", b =>
                {
                    b.Property<int>("KartIdx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("LabTime")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("KartIdx");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Karts");
                });

            modelBuilder.Entity("oneline.Models.Quest", b =>
                {
                    b.Property<int>("QuestIdx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("QuestContent")
                        .HasColumnType("longtext");

                    b.Property<int>("WorldIdx")
                        .HasColumnType("int");

                    b.HasKey("QuestIdx");

                    b.HasIndex("WorldIdx");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("oneline.Models.Score", b =>
                {
                    b.Property<int>("ScoreIdx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MyScore")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("WorldIdx")
                        .HasColumnType("int");

                    b.HasKey("ScoreIdx");

                    b.HasIndex("UserId");

                    b.HasIndex("WorldIdx");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("oneline.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserContent")
                        .HasColumnType("longtext");

                    b.Property<string>("UserImg")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserPassword")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("oneline.Models.World", b =>
                {
                    b.Property<int>("WorldIdx")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WorldCategory")
                        .HasColumnType("longtext");

                    b.Property<string>("WorldContent")
                        .HasColumnType("longtext");

                    b.Property<int>("WorldImg")
                        .HasColumnType("int");

                    b.Property<string>("WorldName")
                        .HasColumnType("longtext");

                    b.Property<int>("WorldScene")
                        .HasColumnType("int");

                    b.HasKey("WorldIdx");

                    b.ToTable("Worlds");
                });

            modelBuilder.Entity("oneline.Models.Achievement", b =>
                {
                    b.HasOne("oneline.Models.Quest", "Quest")
                        .WithMany("Achievements")
                        .HasForeignKey("QuestIdx")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("oneline.Models.User", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId");

                    b.HasOne("oneline.Models.World", "World")
                        .WithMany("Achievements")
                        .HasForeignKey("WorldIdx")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("User");

                    b.Navigation("World");
                });

            modelBuilder.Entity("oneline.Models.Kart", b =>
                {
                    b.HasOne("oneline.Models.User", "User")
                        .WithOne("Kart")
                        .HasForeignKey("oneline.Models.Kart", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("oneline.Models.Quest", b =>
                {
                    b.HasOne("oneline.Models.World", "World")
                        .WithMany("Quests")
                        .HasForeignKey("WorldIdx")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("World");
                });

            modelBuilder.Entity("oneline.Models.Score", b =>
                {
                    b.HasOne("oneline.Models.User", "User")
                        .WithMany("Scores")
                        .HasForeignKey("UserId");

                    b.HasOne("oneline.Models.World", "World")
                        .WithMany("Scores")
                        .HasForeignKey("WorldIdx")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("World");
                });

            modelBuilder.Entity("oneline.Models.Quest", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("oneline.Models.User", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Kart");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("oneline.Models.World", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Quests");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
