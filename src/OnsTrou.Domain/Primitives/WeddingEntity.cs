using OnsTrou.Domain.Entities.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Primitives;

public abstract class WeddingEntity
{
    public string PartitionKey { get; init; }

    public Guid Id { get; init; }

    protected WeddingEntity()
    {
    }

    protected WeddingEntity(string entityName,Guid weddingId, Guid id)
    {
        Id = id;
        PartitionKey = $"{nameof(Wedding)}_{weddingId.ToString()}_{entityName}";

    }
}


