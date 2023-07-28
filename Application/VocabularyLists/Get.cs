using Application.Core;
using Domain.Entities;
using MediatR;
using Persistence;


namespace Application.VocabularyLists
{
  public class Get
  {
    public class Query : IRequest<ResponseHandler<VocabularyList>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ResponseHandler<VocabularyList>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<VocabularyList>> Handle(Query request, CancellationToken cancellationToken)
      {
        var vocabList = await _context.VocabularyLists.FindAsync(request.Id);

        if (vocabList == null)
        {
          return ResponseHandler<VocabularyList>.NotFoundResponse("Vocabulary List");
        }

        return ResponseHandler<VocabularyList>.SuccessResponse(vocabList);
      }
    }
  }
}