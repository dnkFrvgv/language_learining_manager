namespace Application.DTO
{
  public class LearningSpaceDto
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public Guid LanguageId { get; set; }
  }
}