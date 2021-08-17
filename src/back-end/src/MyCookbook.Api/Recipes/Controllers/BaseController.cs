using Microsoft.AspNetCore.Mvc;
using MyCookbook.Domain.Common;

namespace MyCookbook.Api.Recipes.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult Result(Response response)
        {
            if (response.ResponseType == ResponseType.BadRequest)
            {
                return BadRequest();
            }
            else if (response.ResponseType == ResponseType.Created)
            {
                return Created("post", response.Data);
            }
            else if (response.ResponseType == ResponseType.NoContent)
            {
                return NoContent();
            }
            else if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            else if (response.ResponseType == ResponseType.Ok)
            {
                return response.Data is null ? NoContent() : Ok(response.Data);
            }

            return Ok();
        }
    }
}
