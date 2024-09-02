namespace NHibernateUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ISessionFactory _sessionFactory;

    public TestController()
    {
        _sessionFactory = NHibernateHelper.CreateSessionFactory();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.CompletedTask;

        return Ok();
    }

    [HttpPost]
    public IActionResult CreateProfile([FromBody] CreateProfileRequest request)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            var profile = new CrdCardMiscAuthProfileDef
            {
                Guid = Guid.NewGuid(),
                Description = request.Description,
                Code = request.Code,
                IsValid = true,
            };

            var profileDetail = new CrdCardMiscAuthProfileDet
            {
                CardMiscAuthProfileGuid = profile.Guid,
                FallbackAmount = request.FallbackAmount,
                CrdCardMiscAuthProfileDef = profile
            };

            profile.CrdCardMiscAuthProfileDet = profileDetail;

            session.Save(profile);
            transaction.Commit();

            return Ok(profile);
        }
    }
}
