﻿using Microsoft.AspNetCore.Mvc;

namespace devboost.challengeday.ProducerAPI.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}
