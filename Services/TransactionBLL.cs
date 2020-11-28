using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_Test_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public class TransactionBLL : ControllerBase, ITransactionManager
    {
        private BankContext _context;
        public TransactionBLL(BankContext context)
        {
            _context = context;
        }
        void UpdateAccount(Guid UserId, decimal Amount)
        {
            var newUser = _context.Accounts.Find(UserId);
            var Saved = false;
            while (!Saved)
            {
                try
                {
                    newUser.Balance += Amount;
                    _context.Accounts.Update(newUser);
                    _context.SaveChanges();
                    Saved = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    newUser = _context.Accounts.Find(UserId);
                }
            }
        }
        public IActionResult History(Guid UserId, DateTime From, DateTime To)
        {
            var temp = _context.Transactions.AsNoTracking().Where(p => p.UserId == UserId && p.Time >= From && p.Time <= To).ToList();
            if (temp.Count != 0)
                return Ok(temp);
            return NotFound();
        }
        public IActionResult AddTransaction(Guid UserId, DateTime TransactionTime, decimal Amount, string Notes)
        {
            var temp = _context.Accounts.Find(UserId);
            if (temp != null)
            {
                if (temp.Balance + Amount >= 0)
                {
                    var newTransaction = new Transactions
                    {
                        UserId = UserId,
                        Time = TransactionTime,
                        Amount = Amount,
                        Notes = Notes
                    };
                    UpdateAccount(UserId, Amount);
                    _context.Transactions.Add(newTransaction);
                    _context.SaveChanges();
                    return Ok(newTransaction);
                }
                return NoContent();
            }
            return NotFound();
        }
    }
}
