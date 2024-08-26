using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }
}
