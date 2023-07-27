namespace Domain.Entities
{
  public class Vocabulary : BaseEntity
  {
    public string Title { get; set; }
    public string ExamplePhrase { get; set; }
    public string Translation { get; set; }
    public DateTime Date { get; set; }
    public StatusVocab Status { get; set; } = StatusVocab.NEW;
    public Guid VocabularyListId { get; set; }
    public VocabularyList VocabularyList { get; set; }
  }

  public enum StatusVocab {
    MEMORIZED = 1,
    NEW = 2,
  }
}