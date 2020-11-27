using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Test_App.Services
{
    public interface IStatisticManager
    {
        /// <summary>
        /// Выводит статистику за день по работе сервиса в разрезе пользователя (Обороты в день у пользователя)
        /// </summary>
        /// <param name="onDate">День</param>
        /// <returns>Статистика</returns>
        IActionResult Statistic(DateTime onDate);
    }
}
