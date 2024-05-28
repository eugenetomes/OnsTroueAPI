using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities
{
    public class Basic : AggregateRoot
    {
        public string Name { get; set; }
        public DateTime DateCreatedUtc { get; set; }

        public Basic() : base(nameof(Basic), Guid.NewGuid())
        {
            
        }

        public Basic(string name) : base(nameof(Basic), Guid.NewGuid())
        {
            Id = Guid.NewGuid();
            Name = name;
            DateCreatedUtc = DateTime.UtcNow;
        }
    }
}