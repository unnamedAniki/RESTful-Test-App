using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public interface ITransactionManager
    {
        /// <summary>
        /// Возвращает историю транзакции у указанного пользователя за период времени
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns>История транзакции</returns>
        IActionResult History(Guid UserId, DateTime From, DateTime To);
        /// <summary>
        /// Добавление транзакции указанному пользователю
        /// </summary>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <param name="TransactionTime">Дата/Время транзакции</param>
        /// <param name="Amount">Кол-во средств</param>
        /// <param name="Notes">Коментарий транзакции</param>
        /// <returns>Транзакция</returns>
        IActionResult AddTransaction(Guid UserId, DateTime TransactionTime, decimal Amount, string Notes);
    }
}
