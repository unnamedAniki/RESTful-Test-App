using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RESTful_Test_App.Models
{
    public class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }
        [Key]
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
