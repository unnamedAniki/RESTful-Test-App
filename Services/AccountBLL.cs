using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_Test_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public class AccountBLL : ControllerBase, IUserCommands
    {
        private BankContext _context;
        public AccountBLL(BankContext context)
        {
            _context = context;
        }

        public IActionResult Balance(Guid UserId)
        {
            var temp = _context.Accounts.Where(p => p.UserId == UserId).FirstOrDefault();
            if (temp != null)
                return Ok(temp);
            return NotFound();
        }
        public IActionResult GetResult()
        {
            var temp = _context.Accounts.ToList();
            if (temp.Count != 0)
                return Ok(temp);
            return NotFound();
        }
    }
}
