namespace NHibernateUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private static ISessionFactory _sessionFactory;
    private static NHibernate.ISession _session;

    public ProfilesController()
    {
        if (_sessionFactory == null)
        {
            _sessionFactory = NHibernateHelper.CreateSessionFactory();
            _session = NHibernateHelper.GetCurrentSession();
        }
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetProfiles()
    {
        using (var transaction = _session.BeginTransaction())
        {
            var profiles = _session.Query<CrdCardMiscAuthProfileDef>().ToList();
            transaction.Commit();
            return Ok(profiles);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProfileById(Guid id)
    {
        using (var transaction = _session.BeginTransaction())
        {
            var profile = _session.Get<CrdCardMiscAuthProfileDef>(id);
            if (profile == null)
            {
                return NotFound();
            }
            transaction.Commit();
            return Ok(profile);
        }
    }

    [HttpPost]
    public IActionResult CreateProfile([FromBody] CreateProfileRequest request)
    {
        using (var transaction = _session.BeginTransaction())
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

            _session.Save(profile);
            transaction.Commit();

            return Ok(profile);
        }
    }
}
