using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.LearningSpaces
{
  public class GetAll
  {
     public class Query : IRequest<ResponseHandler<List<LearningSpace>>>
    {

    }

    public class Handler : IRequestHandler<Query, ResponseHandler<List<LearningSpace>>>
    {

      private readonly DataContext _context;
      public Handler(DataContext context){
        _context = context;
      }

      public async Task<ResponseHandler<List<LearningSpace>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return ResponseHandler<List<LearningSpace>>.SuccessResponse(await _context.LearningSpaces.ToListAsync());
      }
    }
  }
}