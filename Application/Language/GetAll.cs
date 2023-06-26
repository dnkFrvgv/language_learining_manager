using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
// using Domain.Entities;

namespace Application.Language
{
  public class GetAll
  {
    public class Query : IRequest<List<Domain.Entities.Language>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Domain.Entities.Language>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }

      public async Task<List<Domain.Entities.Language>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Languages.ToListAsync();
      }
    }
  }
}