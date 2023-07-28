using Domain.Entities;

namespace Application.DTO
{
  public class VocabularyDto
  {
    public string Title { get; set; }
    public string ContextPhrase { get; set; }
    public string Translation { get; set; }
    public String Source { get; set; }
    public Guid VocabularyListId { get; set; }
    public StatusVocab Status { get; set; }
  }
}