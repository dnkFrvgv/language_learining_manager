using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class VocabularyTag
  {
    public Guid VocabularyId { get; set; }
    public Vocabulary Vocabulary { get; set; }
    public Guid TagId { get; set; }
    public TagForVocab Tag { get; set; }
  }
}