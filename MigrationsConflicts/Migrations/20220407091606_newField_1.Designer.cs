﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MigrationsConflicts.Data;

namespace MigrationsConflicts.Migrations
{
    [DbContext(typeof(DMPContext))]
    [Migration("20220407091606_newField_1")]
    partial class newField_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field_B")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field_C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewField")
                        .HasColumnType("int");

                    b.Property<int>("NewField_1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
