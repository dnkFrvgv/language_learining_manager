using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence;
using Application.Core;

namespace Application.Languages
{
  public class Create
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public Language Language { get; set; }
    }

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }
      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Languages.Add(request.Language);
        await _context.SaveChangesAsync();
        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}