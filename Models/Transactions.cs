using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RESTful_Test_App.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionsId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}
