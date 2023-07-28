using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Vocabularies
{
  public class Get
  {
    public class Query : IRequest<ResponseHandler<Vocabulary>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ResponseHandler<Vocabulary>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Vocabulary>> Handle(Query request, CancellationToken cancellationToken)
      {
        var vocabulary = await _context.Vocabularies.FindAsync(request.Id);

        if(vocabulary == null){
          return ResponseHandler<Vocabulary>.NotFoundResponse("Vocabulary");
        }

        return ResponseHandler<Vocabulary>.SuccessResponse(vocabulary);
      }
    }
  }
}