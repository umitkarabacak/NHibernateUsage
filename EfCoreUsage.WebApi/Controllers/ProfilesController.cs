namespace EfCoreUsage.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IActionResult GetProfiles()
    {
        // Eager loading kullanarak ilişkili varlığı dahil et
        var profiles = context.CrdCardMiscAuthProfileDefs
            .Include(p => p.CrdCardMiscAuthProfileDet) // İlişkili varlığı yükle
            .ToList();

        return Ok(profiles);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProfileById(Guid id)
    {
        // Eager loading kullanarak ilişkili varlığı dahil et
        var profile = context.CrdCardMiscAuthProfileDefs
            .Include(p => p.CrdCardMiscAuthProfileDet) // İlişkili varlığı yükle
            .FirstOrDefault(p => p.Guid == id);

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
        context.CrdCardMiscAuthProfileDefs.Add(profile);

        // Yeni profil detayı nesnesi oluştur
        var profileDetail = new CrdCardMiscAuthProfileDet
        {
            CardMiscAuthProfileGuid = profile.Guid,
            FallbackAmount = request.FallbackAmount,
            CrdCardMiscAuthProfileDef = profile
        };

        // Sonra bağlı varlığı kaydet
        context.CrdCardMiscAuthProfileDets.Add(profileDetail);

        // Profil ve profil detayı arasındaki ilişkiyi kur
        profile.CrdCardMiscAuthProfileDet = profileDetail;

        // Veritabanına kaydet
        context.SaveChanges();

        return Ok(profile);
    }
}
