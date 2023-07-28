using MediatR;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Logs;
using Application.DTO;

namespace API.Controllers
{
  public class LogController : BaseApiController
  {
    private readonly IMediator _mediator;
    public LogController(IMediator mediator)
    {
      _mediator = mediator;
    }

    // [HttpGet]
    // public async Task<IActionResult> GetLogs()
    // {
    //   return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    // }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Log>> GetLogById(Guid id)
    // {
    //   return Ok(await _mediator.Send(new Get.Query { Id = id }));
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> EditLog(Guid id, LogDto log)
    // {
    //   return ApiActionResultHandler((await _mediator.Send(new Edit.Command { Log = log, Id = id })));
    // }

    [HttpPost]
    public async Task<IActionResult> CreateLog(LogDto log)
    {
      return Ok(await _mediator.Send(new Create.Command { Log = log }));
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteLog(Guid id)
    // {
    //   return ApiActionResultHandler((await _mediator.Send(new Delete.Command { Id = id })));
    // }
  }
}