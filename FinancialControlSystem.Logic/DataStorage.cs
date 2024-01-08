using FinancialControlSystem.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControlSystem.Logic
{
    public class DataStorage
    {
        private Dictionary<int, TransactionCategoryModel> _transactionCategorys;
        private Dictionary<int, TransactionModel> _transactions;
        private Dictionary<int, ClientFinanceModel> _clientsFinance;
        public DataStorage()
        {
            _transactionCategorys=new Dictionary<int, TransactionCategoryModel>();
            _transactions=new Dictionary<int, TransactionModel>();
            _clientsFinance=new Dictionary<int, ClientFinanceModel>();
        }
        public void AddCategory (TransactionCategoryModel category)
        {
               _transactionCategorys.Add(category.Id, category);
        }
        public void DeletCategoryById ( int Id)
        {
            _transactionCategorys.Remove(Id);
        }
        public  TransactionCategoryModel GetCategoryModelById ( int Id)
        {
             return _transactionCategorys[Id];
        }
        public List<TransactionCategoryModel> GetAllCategoryModels () 
        {
            return _transactionCategorys.Values.ToList();
        }
    }
}
