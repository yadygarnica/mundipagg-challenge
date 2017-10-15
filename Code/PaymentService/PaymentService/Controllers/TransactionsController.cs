//author:Yadira Garnica Bonome
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using PaymentService.Models;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient;
using System.Diagnostics;

namespace PaymentService.Controllers
{
    public class TransactionsController : ApiController
    {
        private static readonly ITransactionRepository transactions = new TransactionRepository(" ");


        /// <summary>
        /// Get all transaction in the database when GET requets is called: api/Transactions
        /// </summary>
        /// <returns>IEnumerable of transactions</returns>
        public IEnumerable<Transaction> Get()
        {
            var result = transactions.GetAllTransactions();
            return result;
        }


        /// <summary>
        /// Get a transaction when GET requets is called: api/Transactions/5
        /// </summary>
        /// <param name="id">id of the transaction tha will be returned</param>
        /// <returns>the trasaction with ID = id</returns>
        public Transaction Get(string id)
        {
            return transactions.GetTransaction(id);
        }

        /// <summary>
        /// Reset the database for test use
        /// </summary>        
        public bool DeleteAll()
        {
            return transactions.ResetDatabase();
        }

        /// <summary>
        ///  Add new transaction to the database and send to mundipagg API, when POST requets is called: api/Transactions
        /// </summary>
        public void Post([FromBody]Transaction value)
        {            
            if (value != null)
            {
                value.MundipaggCreated = AuthorizeTransaction(value);
                transactions.AddTransaction(value);
                   
            }           
        }


        /// <summary>
        /// Update the database when PUT requets is called: api/Transactions/5
        /// </summary>
        /// <param name="id">id of the transaction tha will be updated</param>
        /// <param name="value">new transaction values</param>
        public void Put(string id, [FromBody]Transaction value)
        {
            if (value != null && id != null)
            {
                transactions.UpdateTransaction(id, value);            
            }
        }


        /// <summary>
        /// Delete one element in the database when DELETE requets is called: api/Transactions/5
        /// </summary>
        /// <param name="id">id of the transaction tha will be deleted</param>
        public void Delete(string id)
        {
            if (id != null)
            {
                transactions.RemoveTransaction(id);                   
            }            
        }

        //------Private Methods-----

        //send the transaction to Mundipagg API
        private bool AuthorizeTransaction(Transaction item)
        {

            var cardBrand = CardTypetoEnum(item.CardType);
            //if the card is not supported by Mundipagg Api return
            if (cardBrand == null) return false;           

            // Creates the credit card transaction.
            var transaction = new CreditCardTransaction()
            {
                AmountInCents = (long)double.Parse(item.Value) * 100,
                CreditCard = new CreditCard()
                {
                    CreditCardNumber = item.CardNumber,
                    CreditCardBrand = cardBrand,
                    ExpMonth = item.CardExpMonth,
                    ExpYear = item.CardExpYear,
                    SecurityCode = item.CardCVV,
                    HolderName = item.CardName,
                }
            };

            try
            {
                // Creates the client that will send the transaction.
                var guid = new Guid("85328786-8BA6-420F-9948-5352F5A183EB");
                var uri = new Uri("https://sandbox.mundipaggone.com");
                var serviceClient = new GatewayServiceClient(guid,uri);

                // Authorizes the credit card transaction and returns the gateway response.
                var httpResponse = serviceClient.Sale.Create(transaction);

                // API response code
                Debug.WriteLine("Status: {0}", httpResponse.HttpStatusCode);

                var createSaleResponse = httpResponse.Response;
                if (httpResponse.HttpStatusCode == HttpStatusCode.Created)
                {
                    foreach (var creditCardTransaction in createSaleResponse.CreditCardTransactionResultCollection)
                    {
                        Debug.WriteLine(creditCardTransaction.AcquirerMessage);                        
                    }
                    return true;
                }
                else
                {
                    if (createSaleResponse.ErrorReport != null)
                    {
                        foreach (ErrorItem errorItem in createSaleResponse.ErrorReport.ErrorItemCollection)
                        {
                            Debug.WriteLine("Error {0}: {1}", errorItem.ErrorCode, errorItem.Description);                            
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;         
            }
        }

        //convert the credict card type string to CreditCardBrandEnum
        private CreditCardBrandEnum? CardTypetoEnum(string type)
        {
            switch (type)
            {
                case "visa":
                    return CreditCardBrandEnum.Visa;
                case "dinersclub":
                    return CreditCardBrandEnum.Diners;
                case "mastercard":
                    return CreditCardBrandEnum.Mastercard;
                case "amex":
                    return CreditCardBrandEnum.Amex;
                case "discover":
                    return CreditCardBrandEnum.Discover;
                case "andaraki":
                    return CreditCardBrandEnum.AndarAki;
                case "aura":
                    return CreditCardBrandEnum.Aura;
                case "casashow":
                    return CreditCardBrandEnum.CasaShow;
                case "elo":
                    return CreditCardBrandEnum.Elo;
                case "havan":
                    return CreditCardBrandEnum.Havan;
                case "hipercard":
                    return CreditCardBrandEnum.Hipercard;
                case "hugcard":
                    return CreditCardBrandEnum.HugCard;
                case "leadercard":
                    return CreditCardBrandEnum.LeaderCard;
                default:
                    //this is becouse the credit cards validated, in the javascript used, are not the same that Mundipagg api have,
                    //but for the purpose of the example it will work for:Visa,MasterCard,American Express,Diners Club,Discover.
                    return null;
            }
        }
    }
}
