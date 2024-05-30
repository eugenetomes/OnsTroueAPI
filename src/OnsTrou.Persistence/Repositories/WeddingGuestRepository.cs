using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Entities.WeddingGuestFeature;
using OnsTrou.Domain.Repositories;
using OnsTrou.Domain.ValueObjects;
using OnsTrou.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories
{
    internal sealed class WeddingGuestRepository : RepositoryBase, IWeddingGuestRepository
    {
        private readonly string partitionKey = string.Empty;
        public WeddingGuestRepository(IDynamoDBContext context, ITenantProvider tenantProvider) : base(context, tenantProvider)
        {
            partitionKey = GetWeddingEntityPartitionKey(nameof(WeddingGuest));
        }

        public async Task<List<WeddingGuest>> GetAll(CancellationToken cancellationToken = default)
        {
            

            var queryOperationConfig = GetQueryOperationConfigForPartitionKey(partitionKey);

            var search = _context.FromQueryAsync<WeddingGuest>(queryOperationConfig, _dynamoDBOperationConfig);
            return await search.GetRemainingAsync();
        }
        public async Task Create(WeddingGuest weddingGuest, CancellationToken cancellationToken = default)
        {
            await _context.SaveAsync(weddingGuest, _dynamoDBOperationConfig, cancellationToken);
        }

        public async Task<WeddingGuest> GetByIdAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            var weddingGuest = await _context.LoadAsync<WeddingGuest>(partitionKey, phoneNumber.ToString(), _dynamoDBOperationConfig, cancellationToken);
            return weddingGuest;
        }
    }
}
