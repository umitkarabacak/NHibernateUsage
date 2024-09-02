namespace NHibernateUsage.WebApi.Models;

public record CreateProfileRequest(int Code, string Description, decimal FallbackAmount)
{
}
