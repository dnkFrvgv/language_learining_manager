using Application.Core;
using MediatR;
using Persistence;

namespace Application.Vocabularies
{
  public class Delete
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var vocabulary = await _context.Vocabularies.FindAsync(request.Id);
        
        if (vocabulary == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary");
        }

        _context.Remove(vocabulary);       
        var response = await _context.SaveChangesAsync() > 0;

        if (!response){
          return ResponseHandler<Unit>.FailResponse("Failed to delete vocabulary.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}