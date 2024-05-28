using Amazon.DynamoDBv2.DataModel;
using EasyCompany.GenericResult.Core;
using OnsTrou.Domain.Entities;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Repositories;
using OnsTrou.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories
{
    internal sealed class WeddingRepository : IWeddingRepository
    {
        private readonly IDynamoDBContext _context;

        public WeddingRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task Create(Wedding wedding, CancellationToken cancellationToken = default)
        {
            var config = new DynamoDBOperationConfig
            {
                OverrideTableName = TableConstants.TableName
            };

            var basic = new Basic(wedding.Name);

            await _context.SaveAsync(basic, cancellationToken);
        }

        
    }
}
