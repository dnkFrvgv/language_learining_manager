using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vocabulary : BaseEntity
    {
        public string Title { get; set; }
        public Language Language { get; set; }
        public string ExamplePhrase { get; set; }
        public string Translation { get; set; }
        public List<VocabularyTag> Tags { get; set; }
    }
}