﻿// <auto-generated />
using System;
using BusTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusTickets.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    partial class TicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusTickets.Data.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("BuyerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuyerLastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.ToTable("TicketSet");
                });
#pragma warning restore 612, 618
        }
    }
}
