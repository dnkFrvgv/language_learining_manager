using MediatR;
using Persistence;
using Application.Core;

namespace Application.Languages
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
        var language = await _context.Languages.FindAsync(request.Id);
        _context.Remove(language);
        await _context.SaveChangesAsync();
        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }

  }
}