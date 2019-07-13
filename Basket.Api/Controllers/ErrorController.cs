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
            return ApiResponse.Unauthorized("Unauthorized error");
        }

        [Route("conflict")]
        public async Task<IActionResult> Conflict()
        {
            return ApiResponse.Conflict("Conflict error");
        }

        [Route("internal-server-error")]
        public async Task<IActionResult> InternalServerError()
        {
            return ApiResponse.InternalServerError("Internal Server error");
        }

        [Route("random")]
        public async Task<IActionResult> Random()
        {
            throw new InvalidOperationException("Random exception");
        }

        [Route("random-empty-message")]
        public async Task<IActionResult> RandomEmptyMessage()
        {
            throw new InvalidOperationException("");
        }
    }
}