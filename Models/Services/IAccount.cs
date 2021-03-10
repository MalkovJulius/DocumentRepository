using DocumentRepository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services
{
    /// <summary>
    /// Интерфейс для работы с ORM по акаунтам
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Добавляет аккаунт в БД
        /// </summary>
        /// <param name="account"> DTO акаунта </param>
        /// <returns></returns>
        (string, bool) AddAccount(AccountDto account);

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="account"> DTO акаунта </param>
        /// <returns></returns>
        (string, bool) Login(AccountDto account);
    }
}
