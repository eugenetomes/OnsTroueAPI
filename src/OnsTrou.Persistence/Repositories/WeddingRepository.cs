using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;
using OnsTrou.Persistence.Abstractions;

namespace OnsTrou.Persistence.Repositories;

internal sealed class WeddingRepository : RepositoryBase, IWeddingRepository
{

    public WeddingRepository(IDynamoDBContext context, ITenantProvider tenantProvider) : base(context, tenantProvider)
    {
    }

    public async Task<Wedding> GetMyWedding(CancellationToken cancellationToken = default)
    {
        return await GetByIdAsync(TenantId, cancellationToken);
    }

    public async Task<Wedding> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var wedding = await _context.LoadAsync<Wedding>(nameof(Wedding), Id, _dynamoDBOperationConfig, cancellationToken);
        return wedding;
    }

    public async Task Create(Wedding wedding, CancellationToken cancellationToken = default)
    {
        await _context.SaveAsync(wedding, _dynamoDBOperationConfig, cancellationToken);
    }

    public async Task Update(Wedding wedding, CancellationToken cancellationToken = default)
    {
        await _context.SaveAsync(wedding, _dynamoDBOperationConfig, cancellationToken);
    }
}
