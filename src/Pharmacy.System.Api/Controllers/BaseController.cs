using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.System.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
