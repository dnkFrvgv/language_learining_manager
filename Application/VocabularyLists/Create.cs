
using MediatR;
using Application.Core;
using Persistence;
using Domain.Entities;
using Application.DTO;

namespace Application.VocabularyLists
{
  public class Create
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public VocabularyListDto VocabularyList { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(c => c.LearningSpace).SetValidator(new LearningSpaceDtoValidator());
    //   }
    // }

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var vocabularies = new List<Vocabulary>();
        var space = await _context.LearningSpaces.FindAsync(request.VocabularyList.LearningSpaceId);

        if (space == null)
        {
          return ResponseHandler<Unit>.FailResponse("This space doesn't exist on the database.");
        }

        var VocabList = new VocabularyList()
        {
          Title = request.VocabularyList.Title,
          LearningSpace = space,
          Vocabularies = vocabularies
        };

        _context.VocabularyLists.Add(VocabList);
        await _context.SaveChangesAsync();

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}