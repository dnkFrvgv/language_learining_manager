using MediatR;
using Domain.Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Vocabularies
{
  public class GetAll
  {
    public class Query : IRequest<List<Vocabulary>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Vocabulary>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;        
      }

      public async Task<List<Vocabulary>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Vocabularies.ToListAsync();
      }
    }
  }
}