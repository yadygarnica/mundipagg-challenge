using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShopping.Models
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Return all the products in the database
        /// </summary>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Get the product with the given id
        /// </summary>
        /// <param name="id">id of th product</param>
        /// <returns>the product with the given id</returns>
        Product GetProduct(string id);

        /// <summary>
        /// Add a new product to the database
        /// </summary>
        /// <param name="item">product to add</param>
        /// <returns>null if the operattion fail, or the product inserted</returns>
        Product AddProduct(Product item);

        /// <summary>
        /// Remove the product with the given id
        /// </summary>
        /// <param name="id">id of th product</param>
        /// <returns>true if the operation success false otherwise</returns>
        bool RemoveProduct(string id);

        /// <summary>
        /// Update the product with the given id
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <param name="item">New values to uptdate</param>
        /// <returns>true if the operation success false otherwise</returns>
        bool UpdateProduct(string id, Product item);
    }

    public class ProductsRepository : IProductsRepository
    {
        IMongoCollection<Product> products;
        MongoClient client;
        IMongoDatabase database;
        string database_name = "ProductsDb";
        string collection_name = "products";
        string connection = "mongodb://localhost:27017";
        string commandMongod = @"C:\Program Files\MongoDB\Server\3.2\bin\mongod.exe";
        string mongoParameter = @" --dbpath D:\Github\mundipaggChallenge\Data\MongoDb";

        /// <summary>
        /// Return an intances of ProductsRepository
        /// </summary>
        /// <param name="connection">if is null or whitespace it will be mongodb://localhost:27017</param>
        public ProductsRepository(string connection)
        {
            if (!string.IsNullOrWhiteSpace(connection))
            {
                this.connection = connection; ;
            }
            Process[] pname = Process.GetProcessesByName("mongod");
            if (pname.Length == 0)
            {
                System.Diagnostics.Process.Start(commandMongod, mongoParameter);
            }
            client = new MongoClient(this.connection);
           
            CreateDatabase();
        }

        /// <summary>
        /// Add a new product to the database
        /// </summary>
        /// <param name="item">product to add</param>
        /// <returns>null if the operattion fail, or the product inserted</returns>
        public Product AddProduct(Product item)
        {
            try
            {
                item.Id = ObjectId.GenerateNewId().ToString();
                products.InsertOne(item);
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Return all the products in the database
        /// </summary>
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return products.Find(new BsonDocument()).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get the product with the given id
        /// </summary>
        /// <param name="id">id of th product</param>
        /// <returns>the product with the given id</returns>
        public Product GetProduct(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("_id", id);
                return products.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Remove the product with the given id
        /// </summary>
        /// <param name="id">id of th product</param>
        /// <returns>true if the operation success false otherwise</returns>
        public bool RemoveProduct(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("_id", id);
                var result = products.DeleteOne(filter);
                return result.DeletedCount == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Update the product with the given id
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <param name="item">New values to uptdate</param>
        /// <returns>true if the operation success false otherwise</returns>
        public bool UpdateProduct(string id, Product item)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq("_id", id);
                var update = Builders<Product>.Update.Set("Name", item.Name).Set("Price", item.Price).Set("Category", item.Category);
                var result = products.UpdateOne(filter, update);
                return result.ModifiedCount == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + " : " + ex.Message);
                return false;
            }
        }

        //-------Private Methods-------
        // Reset the database and all collections
        public void ResetDatabase()
        {
            client.DropDatabase(database_name);
            CreateDatabase();
        }

        // Create the database and the collections
        private void CreateDatabase()
        {            
            database = client.GetDatabase(database_name);
            products = database.GetCollection<Product>(collection_name);
        }

    }
}
