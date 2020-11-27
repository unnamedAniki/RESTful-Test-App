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
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;
        private readonly BankContext _context;
        private readonly DefaultData _data;
        private readonly AccountBLL _account;
        private readonly TransactionBLL _transaction;
        private readonly StatisticBLL _statistic;
        public BankController(ILogger<BankController> logger, BankContext context, DefaultData data)
        {
            _logger = logger;
            _context = context;
            _data = data;
            _account = new AccountBLL(_context);
            _transaction = new TransactionBLL(_context);
            _statistic = new StatisticBLL(_context);
        }

        [HttpGet("{id}")]
        public IActionResult GetBalance(Guid Id)
        {
            return _account.Balance(Id);
        }
        [HttpGet()]
        public IActionResult GetResult()
        {
            return _account.GetResult();
        }
        [HttpPut()]
        public IActionResult History(Guid UserId, DateTime From, DateTime To)
        {
            return _transaction.History(UserId, From, To);
        }
        [HttpPost()]
        public IActionResult AddTransaction(Guid UserId, DateTime TransactionTime, decimal Amount, string Notes)
        {
            return _transaction.AddTransaction(UserId, TransactionTime, Amount, Notes);
        }
        [HttpPut("{date}")]
        public IActionResult Statistic(DateTime Date)
        {
            return _statistic.Statistic(Date);
        }
    }
}
