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
    public async Task<IActionResult> GetLearningSpaces()
    {
      return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateLearningSpace(VocabularyListDto vocabularyList)
    {
      return ApiActionResultHandler(await _mediator.Send(new Create.Command { VocabularyList = vocabularyList }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLanguageById(Guid id)
    {
      return ApiActionResultHandler(await _mediator.Send(new Get.Query { Id = id }));
    }


    // [HttpPut("{id}")]
    // public async Task<IActionResult> EditLanguage(Guid id, LearningSpaceDto learningSpace)
    // {
    //   return ApiActionResultHandler((await _mediator.Send(new Edit.Command { LearningSpace = learningSpace, Id=id })));
    // }


    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteLanguage(Guid id){
    //   return ApiActionResultHandler((await _mediator.Send(new Delete.Command{Id=id})));
    // }
  }
}