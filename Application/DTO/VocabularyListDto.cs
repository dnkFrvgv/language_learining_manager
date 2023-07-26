using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class VocabularyListDto
    {
        public string Title { get; set; }
        public Guid LearningSpaceId { get; set; }
    }
}