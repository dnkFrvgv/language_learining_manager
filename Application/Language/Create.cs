using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Language
{
  public class Create
  {
    public class Command : IRequest
    {
      public Domain.Entities.Language Language { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Languages.Add(request.Language);
        await _context.SaveChangesAsync();
        return Unit.Value;
      }
    }
  }
}