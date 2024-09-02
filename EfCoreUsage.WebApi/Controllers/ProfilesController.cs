namespace EfCoreUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProfilesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetProfiles()
    {
        var profiles = _context.CrdCardMiscAuthProfileDefs.ToList();

        if (!profiles.Any())
            return Ok(new { Message = "No profiles found." });

        return Ok(profiles);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProfileById(Guid id)
    {
        var profile = _context.CrdCardMiscAuthProfileDefs.Find(id);
        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    [HttpPost]
    public IActionResult CreateProfile([FromBody] CreateProfileRequest request)
    {
        // Yeni profil nesnesi oluştur
        var profile = new CrdCardMiscAuthProfileDef
        {
            Guid = Guid.NewGuid(),
            Description = request.Description,
            Code = request.Code,
            IsValid = true,
        };

        // İlk olarak ana varlığı kaydet
        _context.CrdCardMiscAuthProfileDefs.Add(profile);

        // Yeni profil detayı nesnesi oluştur
        var profileDetail = new CrdCardMiscAuthProfileDet
        {
            CardMiscAuthProfileGuid = profile.Guid,
            FallbackAmount = request.FallbackAmount,
            CrdCardMiscAuthProfileDef = profile
        };

        // Sonra bağlı varlığı kaydet
        _context.CrdCardMiscAuthProfileDets.Add(profileDetail);

        // Profil ve profil detayı arasındaki ilişkiyi kur
        profile.CrdCardMiscAuthProfileDet = profileDetail;

        // Veritabanına kaydet
        _context.SaveChanges();

        return Ok(profile);
    }
}
