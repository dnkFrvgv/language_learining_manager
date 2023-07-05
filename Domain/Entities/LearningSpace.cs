using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class LearningSpace : BaseEntity
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateTime LastUdpatedDate { get; set; }
    public Language Language {get;set;}
    public Guid LanguageId {get;set;}
    public ICollection<VocabularyTag> Vocabularies{ get; set;}
  }
}