﻿// <auto-generated />
using System;
using DEMO_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEMO_1.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20230823112055_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEMO_1.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Dept_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Dept_Desc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dept_Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Dept_Manager")
                        .HasColumnType("int");

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Manager_hiredate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("DEMO_1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("St_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("St_Address");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("St_Age");

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Dept_Manager")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("St_Fname");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("St_Lname");

                    b.Property<int?>("St_super")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.HasIndex("St_super");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("DEMO_1.Models.Student", b =>
                {
                    b.HasOne("DEMO_1.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dept_Id");

                    b.HasOne("DEMO_1.Models.Student", "Supervisor")
                        .WithMany()
                        .HasForeignKey("St_super");

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("DEMO_1.Models.Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}