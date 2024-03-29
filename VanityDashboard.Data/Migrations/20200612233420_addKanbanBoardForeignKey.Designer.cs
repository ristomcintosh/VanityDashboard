﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VanityDashboard.Data;

namespace VanityDashboard.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200612233420_addKanbanBoardForeignKey")]
    partial class addKanbanBoardForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("VanityDashboard.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VanityDashboard.Data.Mirror", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Mirrors");
                });

            modelBuilder.Entity("VanityDashboard.Data.Models.BaseMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("BaseMaterials");
                });

            modelBuilder.Entity("VanityDashboard.Data.Models.KanbanBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<bool>("ColumnLock")
                        .HasColumnType("boolean");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ColumnPosition")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleteColumn")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsStartColumn")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("KanbanBoard");
                });

            modelBuilder.Entity("VanityDashboard.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CompletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DueOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("KanbanColumnId")
                        .HasColumnType("integer");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime>("OrderedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PaidOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<int?>("VanityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VanityId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VanityDashboard.Data.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("VanityDashboard.Data.Vanity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BaseMaterialId")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<int?>("MirrorId")
                        .HasColumnType("integer");

                    b.Property<int?>("TableId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BaseMaterialId");

                    b.HasIndex("MirrorId");

                    b.HasIndex("TableId");

                    b.ToTable("Vanity");
                });

            modelBuilder.Entity("VanityDashboard.Data.Order", b =>
                {
                    b.HasOne("VanityDashboard.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("VanityDashboard.Data.Vanity", "Vanity")
                        .WithMany()
                        .HasForeignKey("VanityId");
                });

            modelBuilder.Entity("VanityDashboard.Data.Vanity", b =>
                {
                    b.HasOne("VanityDashboard.Data.Models.BaseMaterial", "BaseMaterial")
                        .WithMany()
                        .HasForeignKey("BaseMaterialId");

                    b.HasOne("VanityDashboard.Data.Mirror", "Mirror")
                        .WithMany()
                        .HasForeignKey("MirrorId");

                    b.HasOne("VanityDashboard.Data.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");
                });
#pragma warning restore 612, 618
        }
    }
}
