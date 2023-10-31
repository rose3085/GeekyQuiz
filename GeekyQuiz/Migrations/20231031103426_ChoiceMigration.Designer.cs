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
    [Migration("20231031103426_ChoiceMigration")]
    partial class ChoiceMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeekyQuiz.Models.ChoiceModel", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChoiceId"));

                    b.Property<string>("ChoiceA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChoiceD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId1")
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("GeekyQuiz.Models.QuestionModel", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GeekyQuiz.Models.UserAnswerModel", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<int?>("IsCorrectChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("PlayId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId1")
                        .HasColumnType("int");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnswerId");

                    b.HasIndex("IsCorrectChoiceId");

                    b.HasIndex("QuestionId1");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("GeekyQuiz.Models.ChoiceModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.QuestionModel", "QuestionId")
                        .WithMany()
                        .HasForeignKey("QuestionId1");

                    b.Navigation("QuestionId");
                });

            modelBuilder.Entity("GeekyQuiz.Models.UserAnswerModel", b =>
                {
                    b.HasOne("GeekyQuiz.Models.ChoiceModel", "IsCorrect")
                        .WithMany()
                        .HasForeignKey("IsCorrectChoiceId");

                    b.HasOne("GeekyQuiz.Models.QuestionModel", "QuestionId")
                        .WithMany()
                        .HasForeignKey("QuestionId1");

                    b.Navigation("IsCorrect");

                    b.Navigation("QuestionId");
                });
#pragma warning restore 612, 618
        }
    }
}
