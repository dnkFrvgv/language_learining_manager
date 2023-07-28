using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using Application.DTO;
using AutoMapper;

namespace Application.Vocabularies
{
  public class Create
  {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public VocabularyDto Vocabulary { get; set; }
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

        var vocabularyList = _context.VocabularyLists.Find(request.Vocabulary.VocabularyListId);

        if (vocabularyList == null)
        {
          return ResponseHandler<Unit>.NotFoundResponse("Vocabulary list");
        }

        var vocabulary = new Vocabulary()
        {
          Title = request.Vocabulary.Title,
          ContextPhrase = request.Vocabulary.ContextPhrase,
          Translation = request.Vocabulary.Translation,
          Source = request.Vocabulary.Source,
          DateAdded = DateTime.Now,
          Status = request.Vocabulary.Status,
          VocabularyList = vocabularyList,
          VocabularyListId = vocabularyList.Id
        };

        _context.Vocabularies.Add(vocabulary);

        var response = await _context.SaveChangesAsync() > 0;

        if (!response){
          return ResponseHandler<Unit>.FailResponse("Failed to create new vocabulary.");
        }

        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}