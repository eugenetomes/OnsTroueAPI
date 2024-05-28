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
        //[JsonPropertyName("partitionKey")]
        [DynamoDBHashKey("partitionKey")]
        public string PartitionKey { get; private set; }

        //[JsonPropertyName("id")]
        [DynamoDBHashKey("id")]
        public string Id { get; private set; }

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(string partitionKey, string id)
        {
            PartitionKey = partitionKey;
            Id = id;
        }
    }
}
