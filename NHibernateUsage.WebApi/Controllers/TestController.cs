namespace NHibernateUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;

        return Ok();
    }
}
