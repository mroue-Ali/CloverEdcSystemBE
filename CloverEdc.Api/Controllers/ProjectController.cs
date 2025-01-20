using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloverEdc.Api.Controllers;
    [ApiController]
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        [HttpGet("user")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult User()
        {
            return Ok("Hello User");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return Ok("Hello Admin");
        }
    }
