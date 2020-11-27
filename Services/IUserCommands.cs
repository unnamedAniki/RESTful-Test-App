using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public interface IUserCommands 
    {
        /// <summary>
        /// Возвращает текущий остаток средств у пользователя
        /// </summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <returns>Текущий остаток</returns>
        IActionResult Balance(Guid UserId);
    } 
}
