using OnsTrou.Persistence.Abstractions;

namespace OnsTrou.App.Services;

public sealed class TenantProvider : ITenantProvider
{
    private const string TenandIdHeaderName = "x-tenantId";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetTenantId()
    {
        var tenantHeader = _httpContextAccessor.HttpContext?
            .Request
            .Headers[TenandIdHeaderName];

        if (!tenantHeader.HasValue)
        {
            return Guid.Empty;
        }

        Guid tenantId = Guid.Empty;
        Guid.TryParse(tenantHeader.Value, out tenantId);
        return tenantId;
    }
}
