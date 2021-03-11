using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Net5WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {

        IHostApplicationLifetime _appLifetime;

        public SystemController(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _appLifetime.StopApplication();
            return new EmptyResult();
        }
    }
}
