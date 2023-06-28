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

    public DbSet<Language> Languages { get; set; }
    public DbSet<Vocabulary> Vocabularies { get; set; }

    public DbSet<VocabularyTag> TagsVocabulary { get; set; }

    public Task<Language> FindAsync(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}