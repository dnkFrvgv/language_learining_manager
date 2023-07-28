
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

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var space = await _context.LearningSpaces.FindAsync(request.VocabularyList.LearningSpaceId);

        if (space == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Learning Space");
        }

        var vocabularies = new List<Vocabulary>();
        var VocabList = new VocabularyList()
        {
          Title = request.VocabularyList.Title,
          LearningSpace = space,
          Vocabularies = vocabularies
        };

        _context.VocabularyLists.Add(VocabList);
        var response = await _context.SaveChangesAsync() > 0;

        if(!response){
          return ResponseHandler<Unit>.FailResponse("Failed to create new vocabulary list.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}