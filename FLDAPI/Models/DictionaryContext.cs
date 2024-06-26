using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FLDAPI.Models;

public partial class DictionaryContext : DbContext
{

    public DictionaryContext(DbContextOptions<DictionaryContext> options, IConfiguration configuration) : base(options) { 
        _configuration = configuration;
        }

    private readonly IConfiguration _configuration;

    public virtual DbSet<Entry> Entries { get; set; }

    public virtual DbSet<EntryWord> EntryWords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entries_pkey");

            entity.ToTable("entries");

            entity.HasIndex(e => e.Word, "index_entries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Antonyms).HasColumnName("antonyms");
            entity.Property(e => e.Compare).HasColumnName("compare");
            entity.Property(e => e.Definitions).HasColumnName("definitions");
            entity.Property(e => e.Homophones).HasColumnName("homophones");
            entity.Property(e => e.Hypernyms).HasColumnName("hypernyms");
            entity.Property(e => e.Hyponyms).HasColumnName("hyponyms");
            entity.Property(e => e.PartOfSpeech).HasColumnName("part_of_speech");
            entity.Property(e => e.Plural).HasColumnName("plural");
            entity.Property(e => e.Synonyms).HasColumnName("synonyms");
            entity.Property(e => e.Tenses).HasColumnName("tenses");
            entity.Property(e => e.Word).HasColumnName("word");
        });

        modelBuilder.Entity<EntryWord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entry_words_pkey");

            entity.ToTable("entry_words");

            entity.HasIndex(e => e.Word, "index_entry_word");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Word).HasColumnName("word");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}