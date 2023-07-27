namespace Domain.Entities
{
  public class VocabularyList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid LearningSpaceId { get; set; }
        public LearningSpace LearningSpace { get; set; }
        public ICollection<Vocabulary> Vocabularies { get; set; }
    }
}