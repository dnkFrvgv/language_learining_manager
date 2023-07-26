using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public LearningSpace LearningSpace { get; set; }
        public DateTime LogDate { get; set; }
        public Skill SkillDedicated { get; set; }
        public Double ComprehensionLevel { get; set; }
        public TimeOnly TimeDedicated { get; set; }
        public String Notes { get; set; }
    }
}