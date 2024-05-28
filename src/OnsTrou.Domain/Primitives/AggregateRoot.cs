using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Primitives
{
    public abstract class AggregateRoot
    {
        public string PartitionKey { get; init; }

        public Guid Id { get; init; }

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(string partitionKey, Guid id)
        {
            PartitionKey = partitionKey;
            Id = id;
        }
    }
}
