using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using Application.Core;

namespace Application.Languages
{
  public class Edit
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public Language Language { get; set; }
    }

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }

      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var language = await _context.Languages.FindAsync(request.Language.Id);
        _mapper.Map(request.Language, language);
        await _context.SaveChangesAsync();
        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }


}