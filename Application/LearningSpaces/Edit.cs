using Application.Core;
using Application.DTO;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.LearningSpaces
{
  public class Edit
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public LearningSpaceDto LearningSpace { get; set; }
      public Guid Id { get; set; }
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
        var learningSpace = await _context.LearningSpaces.FindAsync(request.Id);

        if (learningSpace == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Learning Space");
        }

        _mapper.Map(request.LearningSpace, learningSpace);
        var response = await _context.SaveChangesAsync() > 0;

        if (!response)
        {
          return ResponseHandler<Unit>.FailResponse("Failed to edit Learning Space.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}