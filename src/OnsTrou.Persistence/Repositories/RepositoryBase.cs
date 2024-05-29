using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Persistence.Abstractions;
using OnsTrou.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Persistence.Repositories;

internal abstract class RepositoryBase
{

    public readonly Guid TenantId;

    protected RepositoryBase(ITenantProvider tenantProvider)
    {
        TenantId = tenantProvider.GetTenantId();
    }

    public DynamoDBOperationConfig GetConfig()
    {
        var config = new DynamoDBOperationConfig
        {
            OverrideTableName = TableConstants.TableName
        };
        return config;
    }
}