using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Language
{
  public class Get
  {
    public class Query : IRequest<Domain.Entities.Language>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Domain.Entities.Language>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Domain.Entities.Language> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Languages.FindAsync(request.Id);
      }
    }
  }
}