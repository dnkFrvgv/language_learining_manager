using Application.Core;
using MediatR;
using Persistence;

namespace Application.VocabularyLists
{
  public class Delete
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public Guid Id { get; set; }
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
        var vocabList = await _context.VocabularyLists.FindAsync(request.Id);

        if (vocabList == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary List");
        }

        _context.Remove(vocabList);
        var response = await _context.SaveChangesAsync() > 0;

        if (!response)
        {
          return ResponseHandler<Unit>.FailResponse("Failed to delete vocabulary list.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}