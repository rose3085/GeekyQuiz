﻿// <auto-generated />
using System;
using GeekyQuiz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekyQuiz.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231127150835_edit")]
    partial class edit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeekyQuiz.Models.ChoiceModel", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChoiceId"), 1L, 1);

                    b.Property<string>("CorrectOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId1")
                        .HasColumnType("int");

                    b.HasKey("ChoiceId");

                    b.HasIndex("QuestionId1");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("GeekyQuiz.Models.LoginModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("GeekyQuiz.Models.PlayedModel", b =>
                {
                    b.Property<int>("PlayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayId"), 1L, 1);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("PlayId");

                    b.HasIndex("UserId1");

                    b.ToTable("PlayedModel");
                });

            modelBuilder.Entity("GeekyQuiz.Models.QuestionModel", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GeekyQuiz.Models.ResultModel", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreId"), 1L, 1);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayId1")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ScoreId");

                    b.HasIndex("PlayId1");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("GeekyQuiz.Models.UserAnswerModel", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("PlayId1")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId1")
                        .HasColumnType("int");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerId");

                    b.HasIndex("PlayId1");

                    b.HasIndex("QuestionId1");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("GeekyQuiz.Models.ChoiceModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.QuestionModel", "QuestionId")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionId");
                });

            modelBuilder.Entity("GeekyQuiz.Models.PlayedModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.LoginModel", "UserId")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserId");
                });

            modelBuilder.Entity("GeekyQuiz.Models.ResultModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.PlayedModel", "PlayId")
                        .WithMany()
                        .HasForeignKey("PlayId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayId");
                });

            modelBuilder.Entity("GeekyQuiz.Models.UserAnswerModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.PlayedModel", "PlayId")
                        .WithMany()
                        .HasForeignKey("PlayId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeekyQuiz.Models.QuestionModel", "QuestionId")
                        .WithMany()
                        .HasForeignKey("QuestionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayId");

                    b.Navigation("QuestionId");
                });

            modelBuilder.Entity("GeekyQuiz.Models.QuestionModel", b =>
                {
                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
