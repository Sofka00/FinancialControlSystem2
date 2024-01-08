using FinancialControlSystem.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControlSystem.Logic.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Summ { get; set; }
        public DateTime Date { get; set; }
        public int ClientFinanceId { get; set; }   // Ссылка на клиентские счета
        public int CategoryId { get; set; }
        public TransactionType Type { get; set; }
        public bool IsApproved { get; set; }


    }
}
