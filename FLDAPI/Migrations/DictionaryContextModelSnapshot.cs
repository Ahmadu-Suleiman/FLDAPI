﻿// <auto-generated />
using System.Collections.Generic;
using FLDAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FLDAPI.Migrations
{
    [DbContext(typeof(DictionaryContext))]
    partial class DictionaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FLDAPI.Models.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<string>>("Antonyms")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Compare")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Definitions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Homophones")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Hypernyms")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Hyponyms")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("PartOfSpeech")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plural")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Synonyms")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Tenses")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("FLDAPI.Models.EntryWord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable("EntryWords");
                });
#pragma warning restore 612, 618
        }
    }
}
