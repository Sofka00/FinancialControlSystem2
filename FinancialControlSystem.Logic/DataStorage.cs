using FinancialControlSystem.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace FinancialControlSystem.Logic
{
    public class DataStorage
    {
        [JsonInclude]
        private Dictionary<int, TransactionCategoryModel> _transactionCategorys;
        [JsonInclude]
        private Dictionary<int, TransactionModel> _transactions;
        [JsonInclude]
        private Dictionary<int, ClientFinanceModel> _clientsFinance;
        [JsonInclude]
        private int _transactionsCategoryLastId;
        [JsonInclude]
        private int _clientsFinanceLastId;
        [JsonInclude]
        private int _transactionsLastId;

        public DataStorage()
        {
            _transactionCategorys = new Dictionary<int, TransactionCategoryModel>();
            _transactions = new Dictionary<int, TransactionModel>();
            _clientsFinance = new Dictionary<int, ClientFinanceModel>();

            _transactionsCategoryLastId = 1;
            _transactionsLastId = 1;
            _clientsFinanceLastId = 1;
        }
        public void SaveAll()
        {
            string json = JsonSerializer.Serialize(this);    // this- хранит ссылку на тот объект, который вызвал метод
            using (StreamWriter writer = new StreamWriter("DataStorage.json", false))
            {
                writer.Write(json);
                writer.Close();
            }
        }
        public void LoadAll()
        {
            string json;
            using (StreamReader reader = new StreamReader("DataStorage.json"))
            {
                json = reader.ReadToEnd();
                reader.Close();
            }
            DataStorage tmp =JsonSerializer.Deserialize<DataStorage>(json);
            _clientsFinance=tmp._clientsFinance; 
            _transactions=tmp._transactions;
            _transactionCategorys = tmp._transactionCategorys;
            _clientsFinanceLastId=tmp._clientsFinanceLastId;
            _transactionsCategoryLastId=tmp._transactionsCategoryLastId;
            _transactionsLastId=tmp._transactionsLastId;
                
        }
        public void AddCategory(TransactionCategoryModel category)
        {                                                           
            _transactionCategorys.Add(category.Id, category);
        }
        public void DeletCategoryById(int Id)
        {
            _transactionCategorys.Remove(Id);
        }
        public TransactionCategoryModel GetCategoryModelById(int Id)
        {
            return _transactionCategorys[Id];
        }
        public List<TransactionCategoryModel> GetAllCategoryModels()
        {
            return _transactionCategorys.Values.ToList();
        }
        public void AddTransaction(TransactionModel transaction)
        {
            transaction.Id = _transactionsCategoryLastId;
            _transactions.Add(_transactionsCategoryLastId, transaction);
            _transactionsCategoryLastId++;
        }
        public void DeletTransactionById(int Id)
        {
            _transactions.Remove(Id);
        }

        public TransactionModel GetTransactionById(int Id)
        {
            return _transactions[Id];
        }
        public List<TransactionModel> GetAllTransactionModels()
        {
            return _transactions.Values.ToList();
        }
        public void AddClientFinance(ClientFinanceModel client)
        {
            client.Id = _clientsFinanceLastId;
            _clientsFinance.Add(_clientsFinanceLastId, client);
            _clientsFinanceLastId++;
        }
        public void DeletClientById(int Id)
        {
            _clientsFinance.Remove(Id);
        }
        public ClientFinanceModel GetClientFinanceModelById(int Id)
        {
            return _clientsFinance[Id];
        }
        public List<ClientFinanceModel> GetAllClientFinenceModels()
        {
            return _clientsFinance.Values.ToList();
        }

    }
}
