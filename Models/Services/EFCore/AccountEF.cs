using DocumentRepository.Models.Dtos;
using DocumentRepository.Models.Entities;
using DocumentRepository.Models.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services.EFCore
{
    public class AccountEF : IAccountRep //может статическим
    {
        /// <summary>
        /// Класс по работе с БД через EFCore
        /// </summary>
        public (string, bool) AddAccount(AccountDto accountDto)
        {
            using (var context = new ContextEF())
            {
                var temp = IsAccountExist(accountDto, context);

                if (!temp) {
                    var account = new Account
                    {
                        Login = accountDto.Login,
                        CryptedPassword = accountDto.Password //to crypte password before add new account
                    };
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    //TODO: Залогиниться
                    return ("Успешно добавлен", temp);
                }

                return ("Такой аккаунт уже существует", temp);
            }
        }

        public (string, bool) Login(AccountDto accountDto)
        {
            using (var context = new ContextEF())
            {
                var temp = IsAccountExist(accountDto, context);

                if (temp)
                    //TODO: Залогиниться
                    return ("Успешно вошли в систему", temp);

                return ("Ошибка входа", temp);
            }
        }

        //Проверяет  на наличие в БД аккаунта с таким Логином
        private bool IsAccountExist(AccountDto accountDto, ContextEF context)
        {
            return context.Accounts.Any(x => x.Login == accountDto.Login);
        }
    }
}
