using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories
{
    internal sealed class WeddingRepository : RepositoryBase, IWeddingRepository
    {
        public WeddingRepository()
        {
            
        }

        public async Task Create(Wedding wedding, CancellationToken cancellationToken = default)
        {
            //await _context.SaveAsync(wedding, _dynamoDBOperationConfig, cancellationToken);
            await Task.Delay(1000);
        }
    }
}
