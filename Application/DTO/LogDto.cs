using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LogDto
    {
        public Guid LearningSpaceId { get; set; }
        public DateTime LogDate { get; set; }
        public Guid SkillId { get; set; }     
        public Double ComprehensionLevel { get; set; }
fff         public TimeOnly TimeDedicated { get; set; }
        public String Notes { get; set; }
    }
}