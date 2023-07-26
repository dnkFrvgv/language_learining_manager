// using MediatR;
// using Domain.Entities;
// using Microsoft.AspNetCore.Mvc;
// using Application.Vocabularies;

// namespace API.Controllers
// {
//   public class VocabularyController : BaseApiController
//   {
//     private readonly IMediator _mediator;
//     public VocabularyController(IMediator mediator)
//     {
//       _mediator = mediator;
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetVocabularies() // should return by languageId
//     {
//       return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
//     }

//     // [HttpGet("{id}")]
//     // public async Task<ActionResult<Vocabulary>> GetVocabularyById(Guid id)
//     // {
//     //   return Ok(await _mediator.Send(new Get.Query { Id = id }));
//     // }

//     [HttpPost]
//     public async Task<IActionResult> CreateVocabulary(GetVocabularyDTO vocabulary)
//     {
//       return Ok(await _mediator.Send(new Create.Command { Vocabulary = vocabulary }));
//     }

//   }
// }