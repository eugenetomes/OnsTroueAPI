using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using OnsTrou.Domain.Entities.WeddingFeature;
using OnsTrou.Domain.Primitives;
using OnsTrou.Persistence.Abstractions;
using OnsTrou.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories;

//https://codewithmukesh.com/blog/crud-with-dynamodb-in-aspnet-core/
internal abstract class RepositoryBase
{

    protected readonly Guid TenantId;
    protected readonly DynamoDBOperationConfig _dynamoDBOperationConfig;
    protected readonly IDynamoDBContext _context;

    protected RepositoryBase(IDynamoDBContext context, ITenantProvider tenantProvider)
    {
        TenantId = tenantProvider.GetTenantId();
        _dynamoDBOperationConfig = GetConfig();
        _context = context;
    }

    public DynamoDBOperationConfig GetConfig()
    {
        var config = new DynamoDBOperationConfig
        {
            OverrideTableName = TableConstants.TableName,
        };
        return config;
    }

    public QueryOperationConfig GetQueryOperationConfigForPartitionKey(string partitionKey)
    {
        var queryFilter = new QueryFilter("PartitionKey", QueryOperator.Equal, partitionKey);

        var queryOperationConfig = new QueryOperationConfig
        {
            Filter = queryFilter
        };
        return queryOperationConfig;
    }

    public string GetWeddingEntityPartitionKey(string entityName)
    {
        return $"{nameof(Wedding)}_{TenantId}_{entityName}";
    }
}