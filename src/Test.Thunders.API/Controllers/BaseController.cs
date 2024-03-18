using Microsoft.AspNetCore.Mvc;

namespace Test.Thunders.API.Controllers;

[ApiConventionType(typeof(DefaultApiConventions))]
[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
}
