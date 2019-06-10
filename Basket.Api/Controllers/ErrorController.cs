using Basket.Api.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("not-found")]
        public async Task<IActionResult> NotFound()
        {
            return ApiResponse.NotFound("Not found error");
        }

        [Route("bad-request")]
        public async Task<IActionResult> BadRequest()
        {
            return ApiResponse.BadRequest("Bad request error");
        }

        [Route("forbidden")]
        public async Task<IActionResult> Forbidden()
        {
            return ApiResponse.Forbidden("Forbidden error");
        }

        [Route("no-content")]
        public async Task<IActionResult> NoContent()
        {
            return ApiResponse.NoContent("No content error");
        }

        [Route("unauthorized")]
        public async Task<IActionResult> Unauthorized()
        {
            return ApiResponse.Unauthorized("No content error");
        }

        [Route("conflict")]
        public async Task<IActionResult> Conflict()
        {
            return ApiResponse.Unauthorized("Conflict error");
        }

        [Route("random")]
        public async Task<IActionResult> Random()
        {
            throw new InvalidOperationException("Random exception");
        }
    }
}