﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.DataAccess.MSSQL;

#nullable disable

namespace ToDo.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    partial class ToDoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.ToDoBoard", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.Task", b =>
                {
                    b.HasOne("ToDo.DataAccess.MSSQL.Entities.ToDoBoard", "ToDoBoard")
                        .WithMany("Tasks")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ToDoBoard");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.ToDoBoard", b =>
                {
                    b.HasOne("ToDo.DataAccess.MSSQL.Entities.User", "User")
                        .WithMany("ToDoBoard")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.ToDoBoard", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ToDo.DataAccess.MSSQL.Entities.User", b =>
                {
                    b.Navigation("ToDoBoard");
                });
#pragma warning restore 612, 618
        }
    }
}