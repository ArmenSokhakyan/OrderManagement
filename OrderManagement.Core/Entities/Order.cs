using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Entities
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Address { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
