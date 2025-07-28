using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyArticles.Services;

namespace MyArticles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, ILogger logger) : ControllerBase
    {
        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser()
        {
            var result = userService.UpdateUser(new());
            if (result.IsFailed)
            {
                logger.LogError(result.Message);
                return StatusCode((int)result.Code);
            }

            return Ok();
        }
    }
}
