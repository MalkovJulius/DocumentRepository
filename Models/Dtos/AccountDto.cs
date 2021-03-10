using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Dtos
{
    /// <summary>
    /// Дто формы авторизации
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Павроль
        /// </summary>
        public string Password { get; set; }
    }
}
