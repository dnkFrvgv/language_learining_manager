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
        var vocabularyList = await _context.VocabularyLists.FindAsync(request.Id);

        if (vocabularyList == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary List");
        }

        _mapper.Map(request.VocabularyList, vocabularyList);

        var response = await _context.SaveChangesAsync() > 0;
        
        if (!response)
        {
          return ResponseHandler<Unit>.FailResponse("Failed to edit vocabulary list");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }

  }
}