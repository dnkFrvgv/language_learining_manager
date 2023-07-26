// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Domain.Entities;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;
// using Application.Core;

// namespace Application.Vocabularies
// {
//   public class Create
//   {
//     public class Command : IRequest<ResponseHandler<Unit>>
//     {
//       public GetVocabularyDTO Vocabulary { get; set; }
//     }

//     public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
//     {

//       private readonly DataContext _context;
//       public Handler(DataContext context)
//       {
//         _context = context;
//       }
//       public async  Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
//       {

//         var requestVocab = new Vocabulary()
//         {
//           Title = request.Vocabulary.Title,
//           ExamplePhrase = request.Vocabulary.ExamplePhrase,
//           Translation = request.Vocabulary.Translation,
//         };

//         var tags = new List<VocabularyTag>();
//         foreach (var requestTag in (request.Vocabulary.Tags ?? Enumerable.Empty<string>()))
//         {
//           var tagInDatabase = await _context.TagsForVocab.FirstOrDefaultAsync(tag => tag.Title == requestTag);

//           if (tagInDatabase == null)
//           {
//             tagInDatabase = new TagForVocab() { Title = requestTag };

//             await _context.TagsForVocab.AddAsync(tagInDatabase);
//             await _context.SaveChangesAsync();
//           }

//           var vt = new VocabularyTag
//           {
//             Tag = tagInDatabase,
//             Vocabulary = requestVocab
//           };

//           tags.Add(vt);
//         }

//         requestVocab.Tags=tags;

//         _context.Vocabularies.Add(requestVocab);
        
//         var response = await _context.SaveChangesAsync() > 0;

//         if (!response){
//           ResponseHandler<Unit>.FailResponse("Failed to create new vocabulary");
//         }

//         return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
//       }
//     }
//   }

//   public class GetVocabularyDTO
//   {
//     public string Title { get; set; }
//     public string ExamplePhrase { get; set; }
//     public string Translation { get; set; }
//     public string[] Tags { get; set; }
//   }
// }