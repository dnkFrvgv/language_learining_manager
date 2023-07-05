using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.LearningSpaces;
using Application.DTO;
using Domain.Entities;

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
      return ApiActionResultHandler(await _mediator.Send(new Create.Command{LanguageSpace=learningSpace}));
    }
  }
}