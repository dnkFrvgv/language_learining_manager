using Application.Core;
using Application.DTO;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.VocabularyLists
{
  public class Edit
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public VocabularyListDto VocabularyList { get; set; }
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
        // request.LearningSpace.Id = request.Id;

        var vocabularyList = await _context.VocabularyLists.FindAsync(request.Id);

        _mapper.Map(request.VocabularyList, vocabularyList);
        
        await _context.SaveChangesAsync();
        
        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }

  }
}