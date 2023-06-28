using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Vocabularies
{
  public class Get
  {
    public class Query : IRequest<Vocabulary>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Vocabulary>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Vocabulary> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Vocabularies.FindAsync(request.Id);
      }
    }
  }
}