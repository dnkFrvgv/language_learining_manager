using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Languages
{
  public class Get
  {
    public class Query : IRequest<Language>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Language>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Language> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Languages.FindAsync(request.Id);
      }
    }
  }
}