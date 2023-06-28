using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Languages
{
  public class Edit
  {
    public class Command : IRequest
    {
      public Language Language { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var language = await _context.Languages.FindAsync(request.Language.Id);
        _mapper.Map(request.Language, language);
        await _context.SaveChangesAsync();
        return Unit.Value;
      }
    }
  }


}