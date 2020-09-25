using Microsoft.AspNetCore.Mvc;

namespace devboost.challengeday.API.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}
