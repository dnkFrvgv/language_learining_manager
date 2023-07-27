using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.VocabularyLists;
using Application.DTO;
using Domain.Entities;

namespace API.Controllers
{
  public class VocabularyListController : BaseApiController
  {
    private readonly IMediator _mediator;
    public VocabularyListController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetVocabularies()
    {
      return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVocabularyList(VocabularyListDto vocabularyList)
    {
      return ApiActionResultHandler(await _mediator.Send(new Create.Command { VocabularyList = vocabularyList }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVocabularyListById(Guid id)
    {
      return ApiActionResultHandler(await _mediator.Send(new Get.Query { Id = id }));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> EditVocabularyList(Guid id, VocabularyListDto vocabList){
      return ApiActionResultHandler((await _mediator.Send(new Edit.Command { VocabularyList = vocabList, Id=id })));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVocabularyList(Guid id){
      return ApiActionResultHandler((await _mediator.Send(new Delete.Command{Id=id})));
    }
  }
}