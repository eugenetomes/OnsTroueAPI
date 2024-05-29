using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;
using OnsTrou.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories
{
    internal sealed class WeddingRepository : RepositoryBase, IWeddingRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly DynamoDBOperationConfig _dynamoDBOperationConfig;
        

        public WeddingRepository(IDynamoDBContext context, ITenantProvider tenantProvider):base(tenantProvider)
        {
            _context = context;
            _dynamoDBOperationConfig = GetConfig();
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
    }
}
