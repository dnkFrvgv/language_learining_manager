using MediatR;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Vocabularies;
using Application.DTO;

namespace API.Controllers
{
  public class VocabularyController : BaseApiController
  {
    private readonly IMediator _mediator;
    public VocabularyController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetVocabularies()
    {
      return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vocabulary>> GetVocabularyById(Guid id)
    {
      return Ok(await _mediator.Send(new Get.Query { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditVocabulary(Guid id, VocabularyDto vocabulary)
    {
      return ApiActionResultHandler((await _mediator.Send(new Edit.Command { Vocabulary = vocabulary, Id=id })));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVocabulary(VocabularyDto vocabulary)
    {
      return Ok(await _mediator.Send(new Create.Command { Vocabulary = vocabulary }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVocabulary(Guid id){
      return ApiActionResultHandler((await _mediator.Send(new Delete.Command{Id=id})));
    }

  }
}