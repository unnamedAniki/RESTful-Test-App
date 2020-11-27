using Microsoft.AspNetCore.Mvc;
using RESTful_Test_App.Models;
using RESTful_Test_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public class StatisticBLL : ControllerBase, IStatisticManager
    {
        private BankContext _context;
        public StatisticBLL(BankContext context)
        {
            _context = context;
        }
        public IActionResult Statistic(DateTime Date)
        {
            var temp = _context.Transactions.Where(p => p.Time.Day == Date.Day).AsEnumerable().GroupBy(p => p.UserId).Select(p => new StatisticViewModel{ Name = p.Key, Count = p.Count() }).ToList();
            if (temp != null)
            {
                return Ok(temp);
            }
            return NotFound();
        }
    }
}
