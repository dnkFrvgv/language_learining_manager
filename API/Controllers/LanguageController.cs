using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Language;

namespace API.Controllers
{
  public class LanguageController : BaseApiController
  {
    private readonly IMediator _mediator;
    public LanguageController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Language>>> GetLanguages()
    {
      return await _mediator.Send(new GetAll.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Language>> GetLanguageById(Guid id)
    {
      return await _mediator.Send(new Get.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateLanguage(Language language)
    {
      return Ok(await _mediator.Send(new Create.Command { Language = language }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditLanguage(Guid id, Language language)
    {
      language.Id = id;
      return Ok(await _mediator.Send(new Edit.Command { Language = language }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLanguage(Guid id){
      return Ok(await _mediator.Send(new Delete.Command{Id=id}));
    }
  }
}