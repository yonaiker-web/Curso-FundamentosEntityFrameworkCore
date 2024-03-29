﻿// <auto-generated />
using System;
using FEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FundamentosEntityFramework.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FEF.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce623"),
                            Name = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoryId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce6af"),
                            Name = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("FEF.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce610"),
                            CategoryId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce623"),
                            Creation = new DateTime(2022, 7, 25, 14, 18, 10, 81, DateTimeKind.Local).AddTicks(8523),
                            PriorityTask = 1,
                            Title = "Pago de servicios publicos"
                        },
                        new
                        {
                            TaskId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce611"),
                            CategoryId = new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce6af"),
                            Creation = new DateTime(2022, 7, 25, 14, 18, 10, 81, DateTimeKind.Local).AddTicks(8550),
                            PriorityTask = 0,
                            Title = "Terminar de ver Pelicula en Netflix"
                        });
                });

            modelBuilder.Entity("FEF.Task", b =>
                {
                    b.HasOne("FEF.Category", "Category")
                        .WithMany("Task")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FEF.Category", b =>
                {
                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}
