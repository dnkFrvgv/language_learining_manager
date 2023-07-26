using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class Vocabulary : BaseEntity
  {
    public string Title { get; set; }
    public string ExamplePhrase { get; set; }
    public string Translation { get; set; }
    public DateTime Date { get; set; }
    public StatusVocab Status { get; set; } = StatusVocab.NEW;
    public VocabularyList VocabularyList { get; set; }
    // public Guid LanguageId {get;set;}
    // public Language Language { get; set; }
    // public ICollection<VocabularyTag> Tags { get; set; }

    // add customTags vs fixed tags
    // fixed tags -> ajectives/nouns/verbs etc
    // custom tags -> phrases/idioms/ etc

    // status //to learn // in progress // solidified

    /* 
    thinking about connecting writing journals/stories with the vocab added
    like you could check if the vocab i learned was used in a journal or a story
    */

    // add date field
  }

  public enum StatusVocab {
    MEMORIZED = 1,
    NEW = 2,
  }
}