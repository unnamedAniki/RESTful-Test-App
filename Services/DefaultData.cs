using RESTful_Test_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public class DefaultData 
    {
        public DefaultData()
        {
            using (var context = new BankContext())
            {
                if (!context.Accounts.Any())
                {
                    context.Accounts.AddRange(new List<Accounts>
                    {
                        new Accounts
                        {
                            UserId = Guid.NewGuid(),
                            Balance = 100000
                        },
                        new Accounts
                        {
                            UserId = Guid.NewGuid(),
                            Balance = 75000
                        },
                        new Accounts
                        {
                            UserId = Guid.NewGuid(),
                            Balance = 50000
                        }
                    });
                    context.SaveChanges();
                }
            } 
        }
    }
}
