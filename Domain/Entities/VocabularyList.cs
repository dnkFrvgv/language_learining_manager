using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class VocabularyList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public LearningSpace LearningSpace { get; set; }
        public ICollection<Vocabulary> Vocabularies { get; set; }
    }
}