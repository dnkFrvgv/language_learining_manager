using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Domain.Entities;

namespace Application.Languages
{
  public class GetAll
  {
    public class Query : IRequest<List<Language>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Language>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }

      public async Task<List<Language>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Languages.ToListAsync();
      }
    }
  }
}