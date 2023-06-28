using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Vocabularies
{
  public class Create
  {
    public class Command : IRequest
    {
      public string Title { get; set; }
      public string ExamplePhrase { get; set; }
      public string Translation { get; set; }
      public string[] Tags { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {

      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {

        var tags = new List<VocabularyTag>();
        foreach (var t in (request.Tags ?? Enumerable.Empty<string>()))
        {
          var tagInDb = await _context.TagsVocabulary.FirstOrDefaultAsync(tag => tag.Title == t);

          if (tagInDb == null)
          {
            tagInDb = new VocabularyTag() { Title = t };

            _context.TagsVocabulary.Add(tagInDb);
            await _context.SaveChangesAsync();
          }
          tags.Add(tagInDb);
        }

        var newVocab = new Vocabulary()
        {
          Title = request.Title,
          ExamplePhrase = request.ExamplePhrase,
          Translation = request.Translation,
          Tags = tags          
        };

        _context.Vocabularies.Add(newVocab);
        await _context.SaveChangesAsync();

        
        return Unit.Value;
      }
    }
  }
}