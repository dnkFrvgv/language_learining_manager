using MediatR;
using Application.Core;
using Application.DTO;
using Persistence;
using Domain.Entities;
using FluentValidation;
using Domain;

namespace Application.LearningSpaces
{
  public class Create
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public LearningSpaceDto LearningSpace { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(c => c.LearningSpace).SetValidator(new LearningSpaceDtoValidator());
      }
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
        var vocabulariesList = new List<VocabularyList>();
        var language = await _context.Languages.FindAsync(request.LearningSpace.LanguageId);

        if (language == null)
        {
          return ResponseHandler<Unit>.FailResponse("This language doesn't exist in the database.");
        }

        var LearningSpace = new LearningSpace()
        {
          Title = request.LearningSpace.Title,
          Description = request.LearningSpace.Description,
          StartDate = request.LearningSpace.StartDate,
          VocabularyLists = vocabulariesList,
          LastUdpatedDate = DateTime.Now,
          Language = language,
          LanguageId = language.Id,
        };

        _context.LearningSpaces.Add(LearningSpace);
        await _context.SaveChangesAsync();

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}