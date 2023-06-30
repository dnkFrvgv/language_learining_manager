using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class BaseApiController : ControllerBase
  {
    protected IActionResult ActionResultHandler<T>(ResponseHandler<T> response)
    {
      if (response.Success)
      {
        return Ok(response.Value);
      }
      if (response.Success && response.Value == null)
      {
        return NotFound();
      }
      return BadRequest(response.ErrorMessage);
    }

  }
}