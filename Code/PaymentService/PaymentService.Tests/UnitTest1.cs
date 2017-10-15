using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentService.Models;
using PaymentService.Controllers;

namespace PaymentService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetResetDatabase_ShouldReturnZeroTransactions()
        {
            var controller = new TransactionsController();
            var result = controller.DeleteAll();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Put_ShouldReturnOK()
        {
            
            var controller = new TransactionsController();

            //need an id the exist in the database      
            var transaction = controller.Get("569fe65b68f98205d4da42d2");
            transaction.MundipaggCreated = false;

            controller.Put(transaction.Id, transaction);                      

        }


        [TestMethod]
        public void GetId_ShouldReturnTransaction()
        {
            var controller = new TransactionsController();

            //need an id the exist in the database
            var id = "569fe65b68f98205d4da42d2";

            var result = controller.Get(id);

            Assert.AreEqual(true,result!=null);            
        }


        [TestMethod]
        public void Post_ShouldReturnOK()
        {
            var controller = new TransactionsController();
            var transactionList = GetTransactions();
       
            foreach (var item in transactionList)
            {
                controller.Post(item);                        
            }
            

        }

        [TestMethod]
        public void Get_ShouldReturnAllTransactions()
        {
            var controller = new TransactionsController();
            var transactionList = GetTransactions();            
            //needs to insert the transaction fisrt
            var result = (IList<Transaction>)controller.Get();

            Assert.AreEqual(transactionList.Count, result.Count);
        }


        //---------Private Methods----------
       
        private IList<Transaction> GetTransactions()
        {
            return new List<Transaction>()
            {
                new Transaction() { CardCVV = "6197", CardExpMonth = 1, CardExpYear = 2040, CardName = "Uzasal Uyewiget", CardNumber = "376240406442606", CardType = "amex", Value = "68.38" },
                new Transaction() { CardCVV = "9423", CardExpMonth = 5, CardExpYear = 2045, CardName = "Orurepoyu Idis", CardNumber = "370878281020058", CardType = "amex", Value = "76.58" },
                new Transaction() { CardCVV = "3911", CardExpMonth = 3, CardExpYear = 2040, CardName = "Ilu Uyuc", CardNumber = "348072934406646", CardType = "amex", Value = "32.04" },
                new Transaction() { CardCVV = "6213", CardExpMonth = 1, CardExpYear = 2031, CardName = "Opa Ufaku", CardNumber = "375730103066832", CardType = "amex", Value = "11.12" },
                new Transaction() { CardCVV = "7522", CardExpMonth = 3, CardExpYear = 2047, CardName = "Atifeyi Obov", CardNumber = "372027118481657", CardType = "amex", Value = "98.75" },
                new Transaction() { CardCVV = "5231", CardExpMonth = 8, CardExpYear = 2028, CardName = "Ude Ehodacuc", CardNumber = "378608716184076", CardType = "amex", Value = "46.52" },
                new Transaction() { CardCVV = "1181", CardExpMonth = 5, CardExpYear = 2024, CardName = "Ezuxozhule Ilavud", CardNumber = "374582281186184", CardType = "amex", Value = "78.41" },
                new Transaction() { CardCVV = "1627", CardExpMonth = 7, CardExpYear = 2044, CardName = "Icotukore Okufoxax", CardNumber = "340975296326897", CardType = "amex", Value = "94.99" },
                new Transaction() { CardCVV = "3297", CardExpMonth = 9, CardExpYear = 2037, CardName = "Eshusalal Ubuyaq", CardNumber = "346638031624828", CardType = "amex", Value = "78.49" },
                new Transaction() { CardCVV = "2615", CardExpMonth = 9, CardExpYear = 2048, CardName = "Uxade Uziwazozhu", CardNumber = "375032237621123", CardType = "amex", Value = "8.52" },
                new Transaction() { CardCVV = "4438", CardExpMonth = 4, CardExpYear = 2030, CardName = "Ezhufumipu Ozasayek", CardNumber = "371742480568029", CardType = "amex", Value = "50.95" },
                new Transaction() { CardCVV = "8092", CardExpMonth = 6, CardExpYear = 2020, CardName = "Izhudeshusho Ahasegid", CardNumber = "371615239939826", CardType = "amex", Value = "64.27" },
                new Transaction() { CardCVV = "1402", CardExpMonth = 12, CardExpYear = 2040, CardName = "Icali Awisomod", CardNumber = "345927685327619", CardType = "amex", Value = "54.42" },
                new Transaction() { CardCVV = "1026", CardExpMonth = 2, CardExpYear = 2028, CardName = "Ofodi Egib", CardNumber = "349113832762307", CardType = "amex", Value = "55.35" },
                new Transaction() { CardCVV = "1635", CardExpMonth = 11, CardExpYear = 2036, CardName = "Awodesush Udavexash", CardNumber = "378420255239042", CardType = "amex", Value = "90.76" },
                new Transaction() { CardCVV = "4436", CardExpMonth = 4, CardExpYear = 2048, CardName = "Ozurakop Apozhiqom", CardNumber = "375425609221334", CardType = "amex", Value = "78.38" },
                new Transaction() { CardCVV = "2671", CardExpMonth = 1, CardExpYear = 2022, CardName = "Osuh Adacesom", CardNumber = "378345477416328", CardType = "amex", Value = "52.32" },
                new Transaction() { CardCVV = "5182", CardExpMonth = 1, CardExpYear = 2032, CardName = "Uvale Ugopiq", CardNumber = "379646358646464", CardType = "amex", Value = "41.39" },
                new Transaction() { CardCVV = "9001", CardExpMonth = 7, CardExpYear = 2030, CardName = "Eshumom Ewedituzh", CardNumber = "375472516651146", CardType = "amex", Value = "87.22" },
                new Transaction() { CardCVV = "5127", CardExpMonth = 7, CardExpYear = 2049, CardName = "Awiro Iyaq", CardNumber = "347153397791764", CardType = "amex", Value = "72.12" },
                new Transaction() { CardCVV = "154", CardExpMonth = 8, CardExpYear = 2045, CardName = "Umilu Uzhosacuqi", CardNumber = "5230852078526683", CardType = "mastercard", Value = "57.79" },
                new Transaction() { CardCVV = "539", CardExpMonth = 1, CardExpYear = 2047, CardName = "Ozo Owogunuri", CardNumber = "5474454671500887", CardType = "mastercard", Value = "97.22" },
                new Transaction() { CardCVV = "428", CardExpMonth = 3, CardExpYear = 2016, CardName = "Ami Ayepat", CardNumber = "5483414506036597", CardType = "mastercard", Value = "49.65" },
                new Transaction() { CardCVV = "478", CardExpMonth = 4, CardExpYear = 2040, CardName = "Asubupo Eyigebu", CardNumber = "5316574913505378", CardType = "mastercard", Value = "39.89" },
                new Transaction() { CardCVV = "640", CardExpMonth = 4, CardExpYear = 2021, CardName = "Asija Ijuj", CardNumber = "5229951817347105", CardType = "mastercard", Value = "79.07" },
                new Transaction() { CardCVV = "308", CardExpMonth = 5, CardExpYear = 2020, CardName = "Uvutubu Orazi", CardNumber = "5271053013741780", CardType = "mastercard", Value = "52.96" },
                new Transaction() { CardCVV = "350", CardExpMonth = 12, CardExpYear = 2034, CardName = "Opos Afibozho", CardNumber = "5505578788415374", CardType = "mastercard", Value = "56.19" },
                new Transaction() { CardCVV = "494", CardExpMonth = 4, CardExpYear = 2029, CardName = "Ozud Iqizhi", CardNumber = "5397741383846879", CardType = "mastercard", Value = "26.66" },
                new Transaction() { CardCVV = "863", CardExpMonth = 11, CardExpYear = 2022, CardName = "Ejevu Udojayew", CardNumber = "5527915793440175", CardType = "mastercard", Value = "73.62" },
                new Transaction() { CardCVV = "377", CardExpMonth = 8, CardExpYear = 2041, CardName = "Ehapoluzh Ihacabez", CardNumber = "5433584518707269", CardType = "mastercard", Value = "99.74" },
                new Transaction() { CardCVV = "196", CardExpMonth = 3, CardExpYear = 2022, CardName = "Enisiqe Uwafeg", CardNumber = "5521730518423497", CardType = "mastercard", Value = "33.64" },
                new Transaction() { CardCVV = "954", CardExpMonth = 2, CardExpYear = 2026, CardName = "Uwazoxuzho Ovahu", CardNumber = "5583434936452528", CardType = "mastercard", Value = "29.69" },
                new Transaction() { CardCVV = "304", CardExpMonth = 4, CardExpYear = 2037, CardName = "Aga Ishabushimi", CardNumber = "5353418181192689", CardType = "mastercard", Value = "41.7" },
                new Transaction() { CardCVV = "909", CardExpMonth = 10, CardExpYear = 2037, CardName = "Uzhole Ishube", CardNumber = "5531739436566277", CardType = "mastercard", Value = "67.86" },
                new Transaction() { CardCVV = "377", CardExpMonth = 10, CardExpYear = 2047, CardName = "Ulapaju Omemok", CardNumber = "5555202323961193", CardType = "mastercard", Value = "45.21" },
                new Transaction() { CardCVV = "715", CardExpMonth = 4, CardExpYear = 2032, CardName = "Urapavizh Ijuzh", CardNumber = "5586611603546883", CardType = "mastercard", Value = "93.75" },
                new Transaction() { CardCVV = "588", CardExpMonth = 6, CardExpYear = 2035, CardName = "Uqece Uhopiwe", CardNumber = "5364318702576401", CardType = "mastercard", Value = "7.19" },
                new Transaction() { CardCVV = "811", CardExpMonth = 12, CardExpYear = 2049, CardName = "Isi Amumugoce", CardNumber = "5261188547171559", CardType = "mastercard", Value = "61.3" },
                new Transaction() { CardCVV = "334", CardExpMonth = 4, CardExpYear = 2020, CardName = "Inip Eshofo", CardNumber = "5239492393183406", CardType = "mastercard", Value = "49.67" },
                new Transaction() { CardCVV = "559", CardExpMonth = 12, CardExpYear = 2045, CardName = "Edadi Izheroti", CardNumber = "5421762180445459", CardType = "mastercard", Value = "82.97" },
                new Transaction() { CardCVV = "790", CardExpMonth = 6, CardExpYear = 2016, CardName = "Ashu Ehezedij", CardNumber = "4556432287026269", CardType = "visa", Value = "26.93" },
                new Transaction() { CardCVV = "974", CardExpMonth = 1, CardExpYear = 2017, CardName = "Uhapozh Otobuzhexo", CardNumber = "4485289511239043", CardType = "visa", Value = "17.8" },
                new Transaction() { CardCVV = "496", CardExpMonth = 5, CardExpYear = 2024, CardName = "Opefi Ozubevu", CardNumber = "4916606818604331", CardType = "visa", Value = "18.97" },
                new Transaction() { CardCVV = "344", CardExpMonth = 12, CardExpYear = 2041, CardName = "Ibedo Evoc", CardNumber = "4485340068746763", CardType = "visa", Value = "73.52" },
                new Transaction() { CardCVV = "611", CardExpMonth = 3, CardExpYear = 2029, CardName = "Ore Ucup", CardNumber = "4716848894336378", CardType = "visa", Value = "37.03" },
                new Transaction() { CardCVV = "993", CardExpMonth = 6, CardExpYear = 2046, CardName = "Uzishef Eguduk", CardNumber = "4716433994589067", CardType = "visa", Value = "68.11" },
                new Transaction() { CardCVV = "706", CardExpMonth = 7, CardExpYear = 2021, CardName = "Abiqafago Uditu", CardNumber = "4556679030599014", CardType = "visa", Value = "67.45" },
                new Transaction() { CardCVV = "756", CardExpMonth = 9, CardExpYear = 2023, CardName = "Ayaw Ushik", CardNumber = "4485384396566790", CardType = "visa", Value = "100.56" },
                new Transaction() { CardCVV = "248", CardExpMonth = 6, CardExpYear = 2046, CardName = "Ofujo Ubipubuno", CardNumber = "4916761308824111", CardType = "visa", Value = "19.07" },
                new Transaction() { CardCVV = "947", CardExpMonth = 11, CardExpYear = 2031, CardName = "Aqebup Uxisharevo", CardNumber = "4916940992979726", CardType = "visa", Value = "19.36" },
                new Transaction() { CardCVV = "657", CardExpMonth = 1, CardExpYear = 2046, CardName = "Ashoveyi Iqamurava", CardNumber = "4556225890983607", CardType = "visa", Value = "6.53" },
                new Transaction() { CardCVV = "536", CardExpMonth = 7, CardExpYear = 2024, CardName = "Umeko Elikehosh", CardNumber = "4485371985451054", CardType = "visa", Value = "97.15" },
                new Transaction() { CardCVV = "526", CardExpMonth = 12, CardExpYear = 2040, CardName = "Ivu Ocug", CardNumber = "4677561899757798", CardType = "visa", Value = "60.31" },
                new Transaction() { CardCVV = "776", CardExpMonth = 4, CardExpYear = 2045, CardName = "Ogebakoyi Alabo", CardNumber = "4716369349099834", CardType = "visa", Value = "56.05" },
                new Transaction() { CardCVV = "289", CardExpMonth = 3, CardExpYear = 2030, CardName = "Erakigu Ezojesho", CardNumber = "4477451560454564", CardType = "visa", Value = "100.66" },
                new Transaction() { CardCVV = "285", CardExpMonth = 9, CardExpYear = 2045, CardName = "Esoza Asijeyoyu", CardNumber = "4485160600500043", CardType = "visa", Value = "90.86" },
                new Transaction() { CardCVV = "602", CardExpMonth = 3, CardExpYear = 2016, CardName = "Irozh Ebozalemo", CardNumber = "4556836014393968", CardType = "visa", Value = "68.48" },
                new Transaction() { CardCVV = "123", CardExpMonth = 11, CardExpYear = 2028, CardName = "Anajuzaka Oxafumak", CardNumber = "4539365543295298", CardType = "visa", Value = "91.48" },
                new Transaction() { CardCVV = "617", CardExpMonth = 10, CardExpYear = 2035, CardName = "Iqeh Ojohati", CardNumber = "4224711201537747", CardType = "visa", Value = "98.77" },
                new Transaction() { CardCVV = "233", CardExpMonth = 1, CardExpYear = 2040, CardName = "Oshejizho Agiwozif", CardNumber = "4929323821296767", CardType = "visa", Value = "98.75" },
                new Transaction() { CardCVV = "175", CardExpMonth = 8, CardExpYear = 2028, CardName = "Ewafuba Eqiwajopu", CardNumber = "38517840991615", CardType = "dinersclub", Value = "51.09" },
                new Transaction() { CardCVV = "631", CardExpMonth = 4, CardExpYear = 2030, CardName = "Uzhiyasush Alir", CardNumber = "38577311192754", CardType = "dinersclub", Value = "64.45" },
                new Transaction() { CardCVV = "806", CardExpMonth = 11, CardExpYear = 2020, CardName = "Ekomu Ovafu", CardNumber = "36645564730042", CardType = "dinersclub", Value = "6.33" },
                new Transaction() { CardCVV = "851", CardExpMonth = 2, CardExpYear = 2023, CardName = "Ugevisa Ujozhacoto", CardNumber = "36816314816023", CardType = "dinersclub", Value = "96.3" },
                new Transaction() { CardCVV = "102", CardExpMonth = 2, CardExpYear = 2043, CardName = "Uya Omigo", CardNumber = "38994133573196", CardType = "dinersclub", Value = "32.64" },
                new Transaction() { CardCVV = "241", CardExpMonth = 12, CardExpYear = 2034, CardName = "Exuzefebo Ijodaf", CardNumber = "30275864566908", CardType = "dinersclub", Value = "97.31" },
                new Transaction() { CardCVV = "101", CardExpMonth = 6, CardExpYear = 2033, CardName = "Onuqatuze Ofukushoc", CardNumber = "30081289809075", CardType = "dinersclub", Value = "44.38" },
                new Transaction() { CardCVV = "920", CardExpMonth = 7, CardExpYear = 2047, CardName = "Ijay Opejepo", CardNumber = "38571434948168", CardType = "dinersclub", Value = "25.87" },
                new Transaction() { CardCVV = "304", CardExpMonth = 10, CardExpYear = 2039, CardName = "Iyugucev Ocizuq", CardNumber = "30392699003013", CardType = "dinersclub", Value = "51.46" },
                new Transaction() { CardCVV = "926", CardExpMonth = 9, CardExpYear = 2040, CardName = "Avide Uret", CardNumber = "30237703739849", CardType = "dinersclub", Value = "22.74" },
                new Transaction() { CardCVV = "689", CardExpMonth = 8, CardExpYear = 2036, CardName = "Uhi Ogozho", CardNumber = "30270990616545", CardType = "dinersclub", Value = "69.81" },
                new Transaction() { CardCVV = "750", CardExpMonth = 11, CardExpYear = 2048, CardName = "Eta Ohiqune", CardNumber = "36564910713034", CardType = "dinersclub", Value = "33.86" },
                new Transaction() { CardCVV = "171", CardExpMonth = 5, CardExpYear = 2048, CardName = "Unova Irisha", CardNumber = "30213303766458", CardType = "dinersclub", Value = "70.3" },
                new Transaction() { CardCVV = "356", CardExpMonth = 10, CardExpYear = 2045, CardName = "Inig Ogax", CardNumber = "30148983505620", CardType = "dinersclub", Value = "36.23" },
                new Transaction() { CardCVV = "731", CardExpMonth = 4, CardExpYear = 2040, CardName = "Ariqo Edotifapi", CardNumber = "36132044303427", CardType = "dinersclub", Value = "81.44" },
                new Transaction() { CardCVV = "577", CardExpMonth = 6, CardExpYear = 2046, CardName = "Izaw Awax", CardNumber = "30020485261616", CardType = "dinersclub", Value = "80.41" },
                new Transaction() { CardCVV = "542", CardExpMonth = 2, CardExpYear = 2022, CardName = "Araja Ecunu", CardNumber = "30065912107767", CardType = "dinersclub", Value = "90.83" },
                new Transaction() { CardCVV = "802", CardExpMonth = 3, CardExpYear = 2030, CardName = "Ave Ufeshusob", CardNumber = "30150453809094", CardType = "dinersclub", Value = "33.85" },
                new Transaction() { CardCVV = "256", CardExpMonth = 1, CardExpYear = 2030, CardName = "Uqenuvaxe Olisamejo", CardNumber = "30025731870433", CardType = "dinersclub", Value = "21.22" },
                new Transaction() { CardCVV = "217", CardExpMonth = 10, CardExpYear = 2035, CardName = "Ixazu Oduxin", CardNumber = "36197556282038", CardType = "dinersclub", Value = "98.01" }
            };
        }
    }
}
