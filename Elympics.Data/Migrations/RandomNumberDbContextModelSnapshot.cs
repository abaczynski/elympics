﻿// <auto-generated />
using Elympics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Elympics.Data.Migrations
{
    [DbContext(typeof(RandomNumberDbContext))]
    partial class RandomNumberDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Elympics.Data.RandomNumberDbContext+RandomNumber", b =>
                {
                    b.Property<int>("NumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NumberId"));

                    b.Property<int>("NumberValue")
                        .HasColumnType("integer");

                    b.HasKey("NumberId");

                    b.ToTable("Numbers");
                });
#pragma warning restore 612, 618
        }
    }
}
