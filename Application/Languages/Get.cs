using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Languages
{
  public class Get
  {
    public class Query : IRequest<ResponseHandler<Language>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ResponseHandler<Language>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Language>> Handle(Query request, CancellationToken cancellationToken)
      {
        return ResponseHandler<Language>.SuccessResponse(await _context.Languages.FindAsync(request.Id));
      }
    }
  }
}