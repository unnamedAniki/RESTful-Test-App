using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RESTful_Test_App.Models;
using RESTful_Test_App.Services;

namespace RESTful_Test_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase, IUserCommands, IStatisticManager
    {
        private readonly ILogger<BankController> _logger;
        private readonly BankContext _context;
        private readonly DefaultData _data;
        public BankController(ILogger<BankController> logger, BankContext context, DefaultData data)
        {
            _logger = logger;
            _context = context;
            _data = data;
        }

        [HttpGet("{id}")]
        public IActionResult Balance(Guid Id)
        {
            var temp = _context.Accounts.Where(p=>p.UserId == Id).ToList();
            if(temp != null)
                return Ok(temp);
            return NotFound();
        }
        [HttpGet()]
        public IActionResult GetResult()
        {
            var temp = _context.Accounts.ToList();
            if(temp.Count != 0)
            {
                return Ok(temp);
            }
            return NotFound();
        }
        [HttpPut()]
        public IActionResult History(Guid UserId, DateTime From, DateTime To)
        {
            var temp = _context.Transactions.AsNoTracking().Where(p => p.UserId == UserId && p.Time >= From && p.Time <= To).ToList();
            if(temp.Count != 0)
                return Ok(temp);
            return NotFound();
        }
        [HttpPost()]
        public IActionResult AddTransaction(Guid UserId, DateTime TransactionTime, decimal Amount, string Notes)
        {
            var temp = _context.Accounts.Find(UserId);
            if(temp != null)
            {
                if(temp.Balance + Amount >= 0)
                {
                    temp.Balance += Amount;
                    var newTransaction = new Transactions
                    {
                        UserId = UserId,
                        Time = TransactionTime,
                        Amount = Amount,
                        Notes = Notes
                    };
                    _context.Transactions.Add(newTransaction);
                    _context.Accounts.Update(temp);
                    _context.SaveChanges();
                    return Ok(newTransaction);
                }
                return Problem("Снимаемая сумма транзакциии должна быть меньше или равна остатку на счете пользователя");
            }
            return NotFound();
        }
        [HttpPut("{date}")]
        public IActionResult Statistic(DateTime Date)
        {
            var temp = _context.Transactions.Where(p => p.Time.Day == Date.Day).AsEnumerable().GroupBy(p=>p.UserId).Select(p=> new { Name = p.Key, Count = p.Count()}).ToList();
            if(temp != null)
            {
                return Ok(temp);
            }
            return NotFound();
        }
    }
}
