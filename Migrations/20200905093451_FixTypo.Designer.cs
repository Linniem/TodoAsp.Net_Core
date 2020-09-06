﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskCore.Models;

namespace TaskCore.Migrations
{
    [DbContext(typeof(MyTaskDbContext))]
    [Migration("20200905093451_FixTypo")]
    partial class FixTypo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskCore.Models.TaskList", b =>
                {
                    b.Property<int>("TaskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TaskListGroupId")
                        .HasColumnType("int");

                    b.Property<string>("TaskListName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskListId");

                    b.HasIndex("TaskListGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskLists");
                });

            modelBuilder.Entity("TaskCore.Models.TaskListGroup", b =>
                {
                    b.Property<int>("TaskListGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskListGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskListGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskListGroups");
                });

            modelBuilder.Entity("TaskCore.Models.TaskUnit", b =>
                {
                    b.Property<int>("TaskUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpiredTodayTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("bit");

                    b.Property<string>("Steps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskListId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskUnitId");

                    b.HasIndex("TaskListId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskUnits");
                });

            modelBuilder.Entity("TaskCore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskCore.Models.TaskList", b =>
                {
                    b.HasOne("TaskCore.Models.TaskListGroup", "TaskListGroup")
                        .WithMany("TaskLists")
                        .HasForeignKey("TaskListGroupId");

                    b.HasOne("TaskCore.Models.User", "User")
                        .WithMany("TaskLists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TaskCore.Models.TaskListGroup", b =>
                {
                    b.HasOne("TaskCore.Models.User", "User")
                        .WithMany("TaskListGroups")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TaskCore.Models.TaskUnit", b =>
                {
                    b.HasOne("TaskCore.Models.TaskList", "TaskList")
                        .WithMany("TaskUnits")
                        .HasForeignKey("TaskListId");

                    b.HasOne("TaskCore.Models.User", "User")
                        .WithMany("TaskUnits")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
