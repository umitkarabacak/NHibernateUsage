namespace NHibernateUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly ISessionFactory _sessionFactory;

    public ProfilesController()
    {
        _sessionFactory = NHibernateHelper.CreateSessionFactory();
    }

    // Tüm profilleri listeleyen uç nokta
    [HttpGet]
    [Route("")]
    public IActionResult GetProfiles()
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            // Tüm profilleri sorgulama
            var profiles = session.Query<CrdCardMiscAuthProfileDef>().ToList();
            transaction.Commit(); // Sorgunun sonunda işlemi onayla (commit)
            return Ok(profiles);
        }
    }


    // Belirli bir id'ye göre profil getiren uç nokta
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProfileById(Guid id)
    {
        using (var session = _sessionFactory.OpenSession())
        {
            var profile = session.Get<CrdCardMiscAuthProfileDef>(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
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
