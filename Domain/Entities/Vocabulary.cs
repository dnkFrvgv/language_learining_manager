namespace Domain.Entities
{
  public class Vocabulary : BaseEntity
  {
    public string Title { get; set; }
    public string ContextPhrase { get; set; }
    public string Translation { get; set; }
    public String Source { get; set; }
    public DateTime DateAdded { get; set; }
    public StatusVocab Status { get; set; } = StatusVocab.NEW;
    public Guid VocabularyListId { get; set; }
    public VocabularyList VocabularyList { get; set; }
  }

  public enum StatusVocab {
    ACTIVE = 1,
    NEW = 2,
    PASSIVE = 3
  }
}