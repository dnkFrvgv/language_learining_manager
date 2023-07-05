using MediatR;
using Domain.Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Core;

namespace Application.Vocabularies
{
  public class GetAll
  {
    public class Query : IRequest<ResponseHandler<List<Vocabulary>>>
    {

    }

    public class Handler : IRequestHandler<Query, ResponseHandler<List<Vocabulary>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;        
      }

      public async Task<ResponseHandler<List<Vocabulary>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return ResponseHandler<List<Vocabulary>>.SuccessResponse(await _context.Vocabularies.ToListAsync());
      }
    }
  }
}