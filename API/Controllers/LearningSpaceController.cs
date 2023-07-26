using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.LearningSpaces;
using Application.DTO;

namespace API.Controllers
{
  public class LearningSpaceController : BaseApiController
  {
    private readonly IMediator _mediator;
    public LearningSpaceController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLearningSpaces()
    {
      return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateLearningSpace(LearningSpaceDto learningSpace)
    {
      return ApiActionResultHandler(await _mediator.Send(new Create.Command { LearningSpace = learningSpace }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLearningSpaceById(Guid id)
    {
      return ApiActionResultHandler(await _mediator.Send(new Get.Query { Id = id }));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> EditLearningSpace(Guid id, LearningSpaceDto learningSpace)
    {
      return ApiActionResultHandler((await _mediator.Send(new Edit.Command { LearningSpace = learningSpace, Id=id })));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLearningSpace(Guid id){
      return ApiActionResultHandler((await _mediator.Send(new Delete.Command{Id=id})));
    }


    [HttpGet("{id}/VocabularyLists")]
    public async Task<IActionResult> GetLearningSpaceVocabLists(Guid id){
      return ApiActionResultHandler((await _mediator.Send(new GetVocabList.Query{LearningSpaceId=id})));
    }
  }
}