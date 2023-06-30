using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Domain.Entities;
using Application.Core;


namespace Application.Languages
{
  public class GetAll
  {
    public class Query : IRequest<ResponseHandler<List<Language>>>
    {

    }

    public class Handler : IRequestHandler<Query, ResponseHandler<List<Language>>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }

      public async Task<ResponseHandler<List<Language>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return ResponseHandler<List<Language>>.SuccessResponse(await _context.Languages.ToListAsync());
      }
    }
  }
}