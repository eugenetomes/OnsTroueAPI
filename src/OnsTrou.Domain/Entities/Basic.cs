using Amazon.DynamoDBv2.DataModel;
using OnsTrou.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Domain.Entities
{
    [DynamoDBTable("test")]
    public class Basic
    {
        [DynamoDBHashKey("id")]
        public string Id { get; private set; }

        [DynamoDBProperty("name")]
        public string Name { get; set; }


        public Basic(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}