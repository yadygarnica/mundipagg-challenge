//author:Yadira Garnica Bonome
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace PaymentService.Models
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Get all transactions in the database
        /// </summary>
        /// <returns>IEnumerable of Transactions</returns>
        IEnumerable<Transaction> GetAllTransactions();

        /// <summary>
        /// Get one specific transaction
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        Transaction GetTransaction(string id);

        /// <summary>
        /// Add new transaction to the data base
        /// </summary>
        /// <param name="item">Transaction to add</param>
        /// <returns>The transaction added with date and id inserted</returns>
        Transaction AddTransaction(Transaction item);

        /// <summary>
        ///  Reset the database and all collections for test use
        /// </summary>
        bool ResetDatabase();

        /// <summary>
        /// Remove one specific transaction from the database
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        bool RemoveTransaction(string id);

        /// <summary>
        /// Update one specific transaction from the database
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        /// <param name="item"></param>
        /// <returns>True if it was successful or false if not</returns>
        bool UpdateTransaction(string id, Transaction item);
    }

    public class TransactionRepository : ITransactionRepository
    {
       IMongoCollection<Transaction> transactions;
       
        MongoClient client;
        IMongoDatabase database;
        string database_name = "TransactionsDb";
        string collection_name = "transactions";
        string connection = "mongodb://localhost:27017";
        string commandMongod = @"C:\Program Files\MongoDB\Server\3.2\bin\mongod.exe";
        string mongoParameter = @" --dbpath D:\Github\mundipaggChallenge\Data\MongoDb";

        /// <summary>
        /// Creates a new instance of the class TransactionRepository
        /// </summary>
        /// <param name="connection">if is null or whitespace, default value is mongodb://localhost:27017</param>
        public TransactionRepository(string connection)
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
        ///  Reset the database and all collections for test use
        /// </summary>
        public bool ResetDatabase()
        {
            try
            {
                client.DropDatabase(database_name);
                if (CreateDatabase()) return true;
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }       

        /// <summary>
        /// Add new transaction to the data base
        /// </summary>
        /// <param name="item">Transaction to add</param>
        /// <returns>The transaction added with date and id inserted</returns>
        public Transaction AddTransaction(Transaction item)
        {
            item.Id = ObjectId.GenerateNewId().ToString();
            item.Date = DateTime.UtcNow;
            try
            {
                transactions.InsertOne(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }           
            return item;
        }

        /// <summary>
        /// Get all transactions in the database
        /// </summary>
        /// <returns>IEnumerable of Transactions</returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            try
            {
                var result = transactions.Find(new BsonDocument()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Get one specific transaction
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        /// <returns></returns>
        public Transaction GetTransaction(string id)
        {
            try
            {
                var filter = Builders<Transaction>.Filter.Eq("_id", id);
                return transactions.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Remove one specific transaction from the database
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        /// <returns>True if it was successful or false if not</returns>
        public bool RemoveTransaction(string id)
        {
            try
            {
                var filter = Builders<Transaction>.Filter.Eq("_id", id);
                var result = transactions.DeleteOne(filter);
                return result.DeletedCount == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Update one specific transaction from the database
        /// </summary>
        /// <param name="id">id assigned when the transaction was inserted in the database</param>
        /// <param name="item"></param>
        /// <returns>True if it was successful or false if not</returns>
        public bool UpdateTransaction(string id, Transaction item)
        {
            try
            {
                var filter = Builders<Transaction>.Filter.Eq("_id", id);
                var update = Builders<Transaction>.Update.Set("MundipaggCreated", item.MundipaggCreated)
                .Set("Date", item.Date)
                .Set("CardCVV", item.CardCVV)
                .Set("CardType", item.CardType)
                .Set("CardNumber", item.CardNumber)
                .Set("CardExpMonth", item.CardExpMonth)
                .Set("CardExpYear", item.CardExpYear)
                .Set("CardName", item.CardName)
                .Set("Value", item.Value);
                var result = transactions.UpdateOne(filter, update);
                return result.ModifiedCount == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }   
        }

        //--------Private Methods--------------

        /// <summary>
        ///  Create the database and the collections
        /// </summary>
        private bool CreateDatabase()
        {
            try
            {
                database = client.GetDatabase(database_name);
                transactions = database.GetCollection<Transaction>(collection_name);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;                
            }
        }

    }
}
