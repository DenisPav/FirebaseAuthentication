using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FirebaseExample.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok(User.Claims.Select(x => new { Name = x.Type, Value = x.Value }));
        }
    }
}