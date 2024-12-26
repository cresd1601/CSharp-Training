﻿using Microsoft.AspNetCore.Mvc;

namespace Shopee.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase { }
}

