using Basket.Api.Framework;
using Microsoft.AspNetCore.Mvc;
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
    }
}