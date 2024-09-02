namespace EfCoreUsage.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    public async Task<IActionResult> Tes() => Ok(DateTime.Now);
}
