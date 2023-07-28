using Application.Core;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.LearningSpaces
{
  public class Get
  {
    public class Query : IRequest<ResponseHandler<LearningSpace>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ResponseHandler<LearningSpace>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<LearningSpace>> Handle(Query request, CancellationToken cancellationToken)
      {
        var space = await _context.LearningSpaces.FindAsync(request.Id);

        if(space == null){
          return ResponseHandler<LearningSpace>.NotFoundResponse("Learning Space");
        }

        return ResponseHandler<LearningSpace>.SuccessResponse(space);
      }
    }
  }
}