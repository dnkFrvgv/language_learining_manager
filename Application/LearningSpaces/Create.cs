using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Core;
using Application.DTO;
using Persistence;
using Domain.Entities;

namespace Application.LearningSpaces
{
  public class Create
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public LearningSpaceDto LanguageSpace { get; set; }
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
        var vocabulariesList = new List<VocabularyTag>();
        var language = await _context.Languages.FindAsync(request.LanguageSpace.LanguageId);

        if (language == null)
        {
          return ResponseHandler<Unit>.FailResponse("This language doesn't exist in the database.");
        }

        var LearningSpace = new LearningSpace()
        {
          Title = request.LanguageSpace.Title,
          Description = request.LanguageSpace.Description,
          StartDate = request.LanguageSpace.StartDate,
          Vocabularies = vocabulariesList,
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