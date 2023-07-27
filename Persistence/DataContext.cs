using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain;

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
    public DbSet<VocabularyList> VocabularyLists { get; set; }
    public DbSet<Log> Logs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<LearningSpace>()
        .HasOne(b => b.Language)
        .WithMany(a => a.LearningSpaces)
        .HasForeignKey(b => b.LanguageId);

      modelBuilder.Entity<VocabularyList>()
        .HasOne(v=>v.LearningSpace)
        .WithMany(l=>l.VocabularyLists)
        .HasForeignKey(v=>v.LearningSpaceId);

      modelBuilder.Entity<Vocabulary>()
        .HasOne(v=>v.VocabularyList)
        .WithMany(vl=>vl.Vocabularies)
        .HasForeignKey(v=>v.VocabularyListId);

      modelBuilder.Entity<Log>()
        .HasOne(l=>l.LearningSpace)
        .WithMany(ls=>ls.Logs)
        .HasForeignKey(l=>l.LearningSpaceId);

      modelBuilder.Entity<Log>()
        .HasOne(l=>l.SkillDedicated)
        .WithMany(s=>s.Logs)
        .HasForeignKey(l=>l.SkillId);

    }
  }
}