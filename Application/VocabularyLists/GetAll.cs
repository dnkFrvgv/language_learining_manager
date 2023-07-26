using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.VocabularyLists
{
  public class GetAll
  {
     public class Query : IRequest<ResponseHandler<List<VocabularyList>>>
    {

    }

    public class Handler : IRequestHandler<Query, ResponseHandler<List<VocabularyList>>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }

      public async Task<ResponseHandler<List<VocabularyList>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var vocabularyLists = await _context.VocabularyLists.Include(s=>s.Vocabularies).ToListAsync();
        
        return ResponseHandler<List<VocabularyList>>.SuccessResponse(vocabularyLists);
      }
    }
  }
}