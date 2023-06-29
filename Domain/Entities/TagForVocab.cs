using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class TagForVocab : BaseEntity
  {
    public string Title { get; set; }
    public ICollection<VocabularyTag> Vocabularies { get; set; }
  }
}