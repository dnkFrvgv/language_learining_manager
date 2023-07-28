using Application.Core;
using Domain.Entities;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.LearningSpaces
{
  public class GetVocabList
  {
    public class Query : IRequest<ResponseHandler<List<VocabularyList>>>
    {
        public Guid LearningSpaceId { get; set; }
    }

    public class Handler : IRequestHandler<Query, ResponseHandler<List<VocabularyList>>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<ResponseHandler<List<VocabularyList>>> Handle(Query request, CancellationToken cancellationToken)
      {

        var vocabularyLists = await _context.VocabularyLists.Where(v=>v.LearningSpaceId==request.LearningSpaceId).Include(s=>s.Vocabularies).ToListAsync();

        return ResponseHandler<List<VocabularyList>>.SuccessResponse(vocabularyLists);
      }
    }
  }
}