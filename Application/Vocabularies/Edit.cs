using Application.Core;
using Application.DTO;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Vocabularies
{
  public class Edit
    {
         public class Command : IRequest<ResponseHandler<Unit>>
    {
      public VocabularyDto Vocabulary { get; set; }
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

        var vocabulary = await _context.Vocabularies.FindAsync(request.Id);

        if(vocabulary == null){
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary");
        }

        var vocabularyList = await _context.VocabularyLists.FindAsync(request.Vocabulary.VocabularyListId);

        if(vocabularyList == null){
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary List with this Id");
        }

        _mapper.Map(request.Vocabulary, vocabulary);

        var response = await _context.SaveChangesAsync() > 0;

        if (!response){
          return ResponseHandler<Unit>.FailResponse("Failed to create new vocabulary.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
    }
}