using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("🎉 Anda berhasil mengakses endpoint rahasia!");
        }
    }
}
