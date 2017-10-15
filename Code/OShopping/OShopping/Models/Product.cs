using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShopping.Models
{
    public class Product
    {
        public double Price { get; set; }

        public string Name { get; set; }

        [BsonId]
        public string Id { get; set; }

        public ProductCategory Category { get; set; }
        
    }

    public enum ProductCategory
    {
        Informatic =1,
        Sport =2,
        Home=3
    }
}
