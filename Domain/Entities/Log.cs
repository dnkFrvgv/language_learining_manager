namespace Domain.Entities
{
  public class Log
    {
        public Guid Id { get; set; }
        public Guid LearningSpaceId { get; set; }
        public LearningSpace LearningSpace { get; set; }
        public DateTime LogDate { get; set; }
        public Guid SkillId { get; set; }
        public Skill SkillDedicated { get; set; }
        public Double ComprehensionLevel { get; set; }
        public TimeOnly TimeDedicated { get; set; }
        public String Notes { get; set; }
    }
}