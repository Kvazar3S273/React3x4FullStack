using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React3x4.Models;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterViewModel model)
        {
            return BadRequest(new {
                message="Такий користувач вже існує!"
            });
            return Ok();
        }
    }
}
