using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Languages;

namespace API.Controllers
{
  public class LanguagesController : BaseApiController
  {
    private readonly IMediator _mediator;
    public LanguagesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLanguages()
    {
      return ApiActionResultHandler(await _mediator.Send(new GetAll.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLanguageById(Guid id)
    {
      return ApiActionResultHandler(await _mediator.Send(new Get.Query { Id = id }));
    }

    // [HttpPost]
    // public async Task<IActionResult> CreateLanguage(Language language)
    // {
    //   return ActionResultHandler((await _mediator.Send(new Create.Command { Language = language })));
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> EditLanguage(Guid id, Language language)
    // {
    //   language.Id = id;
    //   return ActionResultHandler((await _mediator.Send(new Edit.Command { Language = language })));
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteLanguage(Guid id){
    //   return ActionResultHandler((await _mediator.Send(new Delete.Command{Id=id})));
    // }
  }
}