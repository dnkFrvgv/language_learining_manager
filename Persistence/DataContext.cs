using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<LearningSpace> LearningSpaces {get;set;}
    public DbSet<Language> Languages { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Vocabulary> Vocabularies { get; set; }

    public DbSet<TagForVocab> TagsForVocab { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<VocabularyTag>(x => x.HasKey(vt => new { vt.VocabularyId, vt.TagId }));

      modelBuilder.Entity<VocabularyTag>()
        .HasOne(vt => vt.Vocabulary)
        .WithMany(vt => vt.Tags)
        .HasForeignKey(vt => vt.VocabularyId); // fk of this table that points to Vocab

      modelBuilder.Entity<VocabularyTag>()
        .HasOne(vt => vt.Tag)
        .WithMany(vt => vt.Vocabularies)
        .HasForeignKey(vt => vt.TagId);

      modelBuilder.Entity<LearningSpace>()
        .HasOne(b => b.Language)
        .WithMany(a => a.LearningSpaces)
        .HasForeignKey(b => b.LanguageId);
    }
    public Task<Language> FindAsync(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}