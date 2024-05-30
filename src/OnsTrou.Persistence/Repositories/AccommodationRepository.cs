using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;
using OnsTrou.Persistence.Abstractions;
using OnsTrou.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories
{
    

    internal sealed class AccommodationRepository : RepositoryBase, IAccommodationRepository
    {
        public AccommodationRepository(IDynamoDBContext context, ITenantProvider tenantProvider) : base(context, tenantProvider)
        {
        }

        public async Task<List<Accommodation>> GetAll(CancellationToken cancellationToken = default)
        {
            var partitionKey = GetWeddingEntityPartitionKey(nameof(Accommodation));

            var queryOperationConfig = GetQueryOperationConfigForPartitionKey(partitionKey);

            var search = _context.FromQueryAsync<Accommodation>(queryOperationConfig, _dynamoDBOperationConfig);
            return await search.GetRemainingAsync();
        }

        public async Task Create(Accommodation accommodation, CancellationToken cancellationToken = default)
        {
            await _context.SaveAsync(accommodation, _dynamoDBOperationConfig, cancellationToken);
        }
    }
}
